using System;
using CryptoDashboardBlazor.Data.Models;

namespace CryptoDashboardBlazor.Data.Store.Features.Wallet.Actions.SaveSettings
{
    public record SaveSettingsAction
    {
        public SaveSettingsAction(string? apiKey, WalletDto? wallet) => (ApiKey, Wallet) = (apiKey, wallet);
        public string? ApiKey { get; set; }
        public WalletDto? Wallet { get; set; }
    }
}