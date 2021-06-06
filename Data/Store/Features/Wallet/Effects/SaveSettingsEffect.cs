using Fluxor;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoDashboardBlazor.Data.Repositories;
using CryptoDashboardBlazor.Data.Store.Features.Shared.Effects;
using CryptoDashboardBlazor.Data.Store.Features.Wallet.Actions.SaveSettings;

namespace CryptoDashboardBlazor.Data.Store.Features.Wallet.Effects
{
    public class SaveSettingsEffect : BaseEffect<SaveSettingsAction, SaveSettingsSuccessAction, SaveSettingsFailureAction>
    {
        public SaveSettingsEffect(ILogger<BaseEffect<SaveSettingsAction, SaveSettingsSuccessAction, SaveSettingsFailureAction>> logger, HttpClient httpClient, IClientRepository clientRepository) : base(logger, httpClient, clientRepository)
        {
        }

        protected override async Task HandleEffectAsync(SaveSettingsAction action, IDispatcher dispatcher)
        {
            logger.LogInformation($"Start save settings...");
            logger.LogInformation("successfully!");
            dispatcher.Dispatch(new SaveSettingsSuccessAction(action.ApiKey, action.Wallet));
        }
    }
}