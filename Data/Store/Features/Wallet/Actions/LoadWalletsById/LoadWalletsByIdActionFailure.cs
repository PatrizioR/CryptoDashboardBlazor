using CryptoDashboardBlazor.Data.Store.Features.Shared.Actions;

namespace CryptoDashboardBlazor.Data.Store.Features.Wallet.Actions.LoadWalletsById
{
    public record LoadWalletsByIdFailureAction : FailureAction
    {
        public LoadWalletsByIdFailureAction(string errorMessage)
          : base(errorMessage)
        {
        }
    }
}
