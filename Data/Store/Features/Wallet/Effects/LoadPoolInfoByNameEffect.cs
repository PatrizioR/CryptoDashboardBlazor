using System.Net.Http;
using System.Threading.Tasks;
using CryptoDashboardBlazor.Data.Repositories;
using CryptoDashboardBlazor.Data.Store.Features.Shared.Effects;
using CryptoDashboardBlazor.Data.Store.Features.Wallet.Actions.LoadPoolInfoByName;
using Fluxor;
using Microsoft.Extensions.Logging;

namespace CryptoDashboardBlazor.Data.Store.Features.Wallet.Effects
{
    public class LoadPoolInfoByNameEffect : BaseEffect<LoadPoolInfoByNameAction, LoadPoolInfoByNameSuccessAction, LoadPoolInfoByNameFailureAction>
    {
        public LoadPoolInfoByNameEffect(ILogger<BaseEffect<LoadPoolInfoByNameAction, LoadPoolInfoByNameSuccessAction, LoadPoolInfoByNameFailureAction>> logger, HttpClient httpClient, IClientRepository clientRepository) : base(logger, httpClient, clientRepository)
        {
        }

        protected override async Task HandleEffectAsync(LoadPoolInfoByNameAction action, IDispatcher dispatcher)
        {
            logger.LogInformation($"Start...");
            var poolInfo = await clientRepository.GetPoolInfoByNameAsync(action.Name, action.Url, httpClient);
            logger.LogInformation("successfully!");
            dispatcher.Dispatch(new LoadPoolInfoByNameSuccessAction(poolInfo));
        }
    }
}