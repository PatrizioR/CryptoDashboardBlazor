namespace CryptoDashboardBlazor.Data.Models
{
    public class AppConfiguration
    {
        public WalletDto[]? Wallets { get; set; }
        public PoolInfoDto? PoolInfo { get; set; }
        public string? PoolUrl { get; set; }
        public string? EthereumPriceApiUrl { get; set; }
    }
}