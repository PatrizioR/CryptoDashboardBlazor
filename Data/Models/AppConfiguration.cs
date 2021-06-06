using System.Data;

namespace CryptoDashboardBlazor.Data.Models
{
    public class AppConfiguration
    {
        public const string ApiKeyLabel = "{YOUR_API_KEY}";
        public const string WalletLabel = "Wallet";
        public WalletDto[]? Wallets { get; set; }
        public PoolInfoDto? PoolInfo { get; set; }
        public string? PoolUrl { get; set; }
        public string? EthereumPriceApiUrl { get; set; }
    }
}