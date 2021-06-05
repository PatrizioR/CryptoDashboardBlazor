using System;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoDashboardBlazor.Data.Repositories;
using Fluxor;
using Microsoft.Extensions.Logging;

namespace CryptoDashboardBlazor.Data.Store.Features.Shared.Effects
{
    public abstract class BaseEffect<A, S, F>
    {
        protected readonly ILogger<BaseEffect<A, S, F>> logger;
        protected readonly HttpClient httpClient;
        protected readonly IClientRepository clientRepository;

        protected BaseEffect(ILogger<BaseEffect<A, S, F>> logger, HttpClient httpClient, IClientRepository clientRepository) =>
            (this.logger, this.httpClient, this.clientRepository) = (logger, httpClient, clientRepository);

        [EffectMethod]
        public async Task HandleBaseEffectAsync(A action, IDispatcher dispatcher)
        {
            try
            {
                await HandleEffectAsync(action, dispatcher);
            }
            catch (Exception e)
            {
                logger.LogError($"Error executing {action?.GetType().Name} action, reason: {e.Message}");
                var failureAction = (F)Activator.CreateInstance(typeof(F), e.Message)!;

                dispatcher.Dispatch(failureAction);
            }
        }

        protected abstract Task HandleEffectAsync(A action, IDispatcher dispatcher);
    }
}