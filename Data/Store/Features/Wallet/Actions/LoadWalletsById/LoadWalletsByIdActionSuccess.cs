using System.Collections.Generic;
using CryptoDashboardBlazor.Data.Models;

namespace CryptoDashboardBlazor.Data.Store.Features.Wallet.Actions.LoadWalletsById
{
    public record LoadWalletsByIdSuccessAction
    {
        public LoadWalletsByIdSuccessAction(IEnumerable<WalletDto>? wallets) => Wallets = wallets;

        public IEnumerable<WalletDto>? Wallets { get; set; }
    }
}
