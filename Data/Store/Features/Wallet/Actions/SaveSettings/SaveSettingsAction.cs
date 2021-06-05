using System;

namespace CryptoDashboardBlazor.Data.Store.Features.Wallet.Actions.SaveSettings
{
    public record SaveSettingsAction
    {
        public SaveSettingsAction(string? apiUrl) => ApiUrl = apiUrl;
        public string? ApiUrl { get; set; }
    }
}