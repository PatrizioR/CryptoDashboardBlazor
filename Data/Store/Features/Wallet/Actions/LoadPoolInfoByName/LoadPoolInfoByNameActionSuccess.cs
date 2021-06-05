using CryptoDashboardBlazor.Data.Models;

namespace CryptoDashboardBlazor.Data.Store.Features.Wallet.Actions.LoadPoolInfoByName
{
    public record LoadPoolInfoByNameSuccessAction
    {
        public LoadPoolInfoByNameSuccessAction(PoolInfoDto? poolInfo) => (PoolInfo) = (poolInfo);

        public PoolInfoDto? PoolInfo { get; init; }
    }
}
