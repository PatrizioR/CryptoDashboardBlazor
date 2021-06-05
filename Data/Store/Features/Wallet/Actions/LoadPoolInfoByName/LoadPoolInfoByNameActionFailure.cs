using CryptoDashboardBlazor.Data.Store.Features.Shared.Actions;

namespace CryptoDashboardBlazor.Data.Store.Features.Wallet.Actions.LoadPoolInfoByName
{
    public record LoadPoolInfoByNameFailureAction : FailureAction
    {
        public LoadPoolInfoByNameFailureAction(string errorMessage)
          : base(errorMessage)
        {
        }
    }
}
