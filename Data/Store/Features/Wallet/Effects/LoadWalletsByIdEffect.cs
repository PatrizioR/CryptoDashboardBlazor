using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoDashboardBlazor.Data.Models;
using CryptoDashboardBlazor.Data.Repositories;
using CryptoDashboardBlazor.Data.Store.Features.Shared.Effects;
using CryptoDashboardBlazor.Data.Store.Features.Wallet.Actions.LoadWalletsById;
using Fluxor;
using Microsoft.Extensions.Logging;

namespace CryptoDashboardBlazor.Data.Store.Features.Wallet.Effects
{
    public class LoadWalletsByIdEffect : BaseEffect<LoadWalletsByIdAction, LoadWalletsByIdSuccessAction, LoadWalletsByIdFailureAction>
    {
        public LoadWalletsByIdEffect(ILogger<BaseEffect<LoadWalletsByIdAction, LoadWalletsByIdSuccessAction, LoadWalletsByIdFailureAction>> logger, HttpClient httpClient, IClientRepository clientRepository) : base(logger, httpClient, clientRepository)
        {
        }

        protected override async Task HandleEffectAsync(LoadWalletsByIdAction action, IDispatcher dispatcher)
        {
            await Task.CompletedTask;
            logger.LogInformation($"Start load wallets by id...");
            var wallets = await clientRepository.GetAllAsync<WalletDto>(httpClient, action.Wallets?.ToArray());
            logger.LogInformation("successfully load wallets by id!");
            dispatcher.Dispatch(new LoadWalletsByIdSuccessAction(wallets));
        }
    }
}