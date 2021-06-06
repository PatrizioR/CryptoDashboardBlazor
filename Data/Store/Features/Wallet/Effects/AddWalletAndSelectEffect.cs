using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoDashboardBlazor.Data.Models;
using CryptoDashboardBlazor.Data.Repositories;
using CryptoDashboardBlazor.Data.Store.Features.Shared.Effects;
using CryptoDashboardBlazor.Data.Store.Features.Wallet.Actions.AddWalletAndSelect;

namespace CryptoDashboardBlazor.Data.Store.Features.Wallet.Effects
{
    public class AddWalletAndSelectEffect : BaseEffect<AddWalletAndSelectAction, AddWalletAndSelectSuccessAction, AddWalletAndSelectFailureAction>
    {
      public AddWalletAndSelectEffect(ILogger<BaseEffect<AddWalletAndSelectAction, AddWalletAndSelectSuccessAction, AddWalletAndSelectFailureAction>> logger, HttpClient httpClient, IClientRepository clientRepository) : base(logger, httpClient, clientRepository)
      {
      }
        protected override async Task HandleEffectAsync(AddWalletAndSelectAction action, IDispatcher dispatcher)
        {
            await Task.CompletedTask;
            logger.LogInformation($"Start...");
            var newWallet = new WalletDto();
            logger.LogInformation("successfully!");
            dispatcher.Dispatch(new AddWalletAndSelectSuccessAction(newWallet));
        }
    }
}
