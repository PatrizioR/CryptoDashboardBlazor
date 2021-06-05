using System;
using System.Collections.Generic;
using CryptoDashboardBlazor.Data.Models;

namespace CryptoDashboardBlazor.Data.Store.State
{
    public record WalletState : RootState
    {
        public WalletState(bool isLoading, string? currentErrorMessage,
            IEnumerable<WalletDto>? currentWallets, WalletDto? currentWallet, PoolInfoDto? currentPoolInfo, string? currentApiUrl, DateTime? lastUpdate) :
            base(isLoading, currentErrorMessage) =>
            (CurrentWallets, CurrentWallet, CurrentPoolInfo, CurrentApiUrl, LastUpdate) = (currentWallets, currentWallet, currentPoolInfo, currentApiUrl, lastUpdate);
        public IEnumerable<WalletDto>? CurrentWallets { get; init; }
        public WalletDto? CurrentWallet { get; init; }
        public PoolInfoDto? CurrentPoolInfo { get; init; }
        public string? CurrentApiUrl { get; init; }
        public DateTime? LastUpdate { get; set; }
    }
}