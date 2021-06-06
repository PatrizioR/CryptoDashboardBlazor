using CryptoDashboardBlazor.Data.Models;

namespace CryptoDashboardBlazor.Data.Store.Features.Wallet.Actions.AddWalletAndSelect
{
    public record AddWalletAndSelectSuccessAction
    {
        public AddWalletAndSelectSuccessAction(WalletDto? wallet) => Wallet = wallet;
        public WalletDto? Wallet { get; set; }
    }
}
