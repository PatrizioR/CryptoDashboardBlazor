using CryptoDashboardBlazor.Data.Store.Features.Shared.Actions;

namespace CryptoDashboardBlazor.Data.Store.Features.Wallet.Actions.SaveSettings
{
    public record SaveSettingsFailureAction : FailureAction
    {
        public SaveSettingsFailureAction(string errorMessage)
          : base(errorMessage)
        {
        }
    }
}
