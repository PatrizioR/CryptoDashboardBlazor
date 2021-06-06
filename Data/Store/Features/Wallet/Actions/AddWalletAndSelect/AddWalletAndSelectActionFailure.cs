using CryptoDashboardBlazor.Data.Store.Features.Shared.Actions;

namespace CryptoDashboardBlazor.Data.Store.Features.Wallet.Actions.AddWalletAndSelect
{
    public record AddWalletAndSelectFailureAction : FailureAction
    {
        public AddWalletAndSelectFailureAction(string errorMessage)
          : base(errorMessage)
        {
        }
    }
}
