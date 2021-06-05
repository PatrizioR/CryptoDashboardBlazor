using System;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoDashboardBlazor.Data.Repositories;
using Fluxor;
using Microsoft.Extensions.Logging;

namespace CryptoDashboardBlazor.Data.Store.Features.Shared.Effects
{
    public abstract class BaseLoadAllEffect<A, S, F, T> : BaseEffect<A, S, F>
    {
        protected BaseLoadAllEffect(ILogger<BaseLoadAllEffect<A, S, F, T>> logger, HttpClient httpClient, IClientRepository clientRepository) : base(logger, httpClient, clientRepository)
        {
        }

        protected override async Task HandleEffectAsync(A action, IDispatcher dispatcher)
        {
            logger.LogInformation($"Executing load {action?.GetType().Name} action...");
            var items = await clientRepository.GetAllAsync<T>(httpClient);
            logger.LogInformation($"Executed {action?.GetType().Name} action successfully!");
            var successAction = (S)Activator.CreateInstance(typeof(S), items)!;
            dispatcher.Dispatch(successAction);
        }
    }
}