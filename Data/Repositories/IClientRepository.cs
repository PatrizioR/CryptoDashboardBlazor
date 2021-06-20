using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoDashboardBlazor.Data.Models;

namespace CryptoDashboardBlazor.Data.Repositories
{
    public interface IClientRepository
    {
        public Task<IEnumerable<T>> GetAllAsync<T>(HttpClient client, params T[]? args);

        public Task<WalletDto> GetWalletAsync(WalletDto wallet, HttpClient client);

        public Task<IEnumerable<WalletDto>> GetWalletsAsync(HttpClient client, params WalletDto[]? ids);

        public Task<PoolInfoDto> GetPoolInfoByNameAsync(string? name, string? url, HttpClient client);
    }
}