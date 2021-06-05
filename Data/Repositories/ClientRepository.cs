using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CryptoDashboardBlazor.Data.Extensions;
using CryptoDashboardBlazor.Data.Models;

namespace CryptoDashboardBlazor.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public async Task<IEnumerable<T>> GetAllAsync<T>(HttpClient client, params T[]? args)
        {
            if (typeof(T) == typeof(WalletDto))
            {
                var innerArgs = args as WalletDto[];
                return (IEnumerable<T>)(await GetWalletsAsync(client, innerArgs));
            }

            throw new NotSupportedException($"Illegal type {typeof(T).Name}");
        }

        public async Task<PoolInfoDto> GetPoolInfoByNameAsync(string name, string url, HttpClient client)
        {
            PoolInfoDto? poolInfo;
            switch (name.ToLower())
            {
                case "2miners":
                    var value = await client.GetFromJsonAsync<CryptocompareRequestDto>(url);
                    poolInfo = new PoolInfoDto()
                    {
                        CoinInfo = new CoinInfoDto()
                        {
                            Currency = "EUR",
                            Exchange = value?.EUR,
                            MiningName = "MH/s",
                            Name = "ETH"
                        },
                        Name = name,
                        PaymentInterval = 0.05
                    };
                    break;

                default:
                    throw new ArgumentException($"Pool unknown {name}", nameof(name));
            }
            return poolInfo;
        }

        public async Task<WalletDto> GetWalletAsync(WalletDto wallet, HttpClient client)
        {
            var id = wallet?.Id ?? "N/A";
            var name = wallet?.Name;
            var owner = wallet?.Owner;
            var dividerEth = 1000000000.0;
            var dividerEthIo = 1000000000000000000.0;
            var dividerHash = 1000000.0;
            var result = await client.GetFromJsonAsync<MinersStruct>($"https://eth.2miners.com/api/accounts/{id}");
            var balanceResult = await client.GetFromJsonAsync<BalanceDto>($"https://api.etherscan.io/api?module=account&action=balance&address={id}&tag=latest&apikey=2VXPEFW8YY89A512QVE471TBQFUR7J4886");
            var curWallet = new WalletDto()
            {
                Id = id,
                Last24HoursReward = (result?._24hreward ?? 0) / dividerEth,
                Name = name,
                Owner = owner,
                Paid = (result?.Stats?.Paid ?? 0) / dividerEth,
                Balance = balanceResult?.Result.ToLongOrDefault() / dividerEthIo,
                UnconfirmedBalance = (result?.Stats?.Immature ?? 0) / dividerEth,
                UnpaidBalance = (result?.Stats?.Balance ?? 0) / dividerEth,
                Workers = Array.Empty<WorkerDto>()
            };

            if (result?.WorkersTotal > 0)
            {
                List<WorkerDto> workers = new();
                foreach (var worker in result.Workers.DefaultIfNullOrEmpty())
                {
                    workers.Add(new WorkerDto()
                    {
                        Name = worker.Key,
                        LastShareInMinutes = (new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds() - worker.Value.LastBeat) / 60.0,
                        CurrentHashRate = worker.Value.Hr / dividerHash,
                        HashRateLastHour = worker.Value.Hr2 / dividerHash
                    });
                }
                curWallet.Workers = workers.ToArray();
                // TODO
            }
            return curWallet;
        }

        public async Task<IEnumerable<WalletDto>> GetWalletsAsync(HttpClient client, params WalletDto[]? wallets)
        {
            List<WalletDto> currentWallets = new();
            if (wallets?.Any() != true)
            {
                return currentWallets;
            }
            foreach (var wallet in wallets)
            {
                currentWallets.Add(await GetWalletAsync(wallet, client));
            }
            return currentWallets;
        }
    }
}