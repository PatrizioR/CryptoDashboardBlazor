using CryptoDashboardBlazor.Data.Store.State;
using Fluxor;

namespace CryptoDashboardBlazor.Data.Store.Features.Wallet
{
    public class WalletFeature : Feature<WalletState>
    {
        public override string GetName() => nameof(WalletFeature);

        protected override WalletState GetInitialState() =>
            new(false, null, null, null, null, null, null);
    }
}