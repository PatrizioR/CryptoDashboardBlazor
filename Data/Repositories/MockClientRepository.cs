using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoDashboardBlazor.Data.Models;

namespace CryptoDashboardBlazor.Data.Repositories
{
    public class MockClientRepository : IClientRepository
    {
        private static readonly Random rand = new();
        private readonly List<WalletDto> wallets = new();
        private readonly List<PoolInfoDto> poolInfos = new();
        private const double paymentInterval = 0.05;

        public async Task<IEnumerable<T>> GetAllAsync<T>(HttpClient client, params T[]? args)
        {
            if (typeof(T) == typeof(WalletDto))
            {
                var innerArgs = args as WalletDto[];
                return (IEnumerable<T>)(await GetWalletsAsync(client, innerArgs));
            }

            throw new NotSupportedException($"Illegal type {typeof(T).Name}");
        }

        public async Task<PoolInfoDto> GetPoolInfoByNameAsync(string? name, string? url, HttpClient client)
        {
            await Task.CompletedTask;
            var poolInfo = poolInfos.FirstOrDefault(pi => pi.Name == name);
            if (poolInfo == null)
            {
                poolInfo = new PoolInfoDto()
                {
                    Name = name,
                    PaymentInterval = paymentInterval,
                    CoinInfo = new CoinInfoDto()
                    {
                        Currency = "€",
                        Exchange = rand.Next(1800, 2500),
                        Name = "ETH",
                        MiningName = "MH/s"
                    }
                };
                poolInfos.Add(poolInfo);
            }
            return poolInfo;
        }

        public async Task<WalletDto> GetWalletAsync(WalletDto wallet, HttpClient client)
        {
            await Task.CompletedTask;
            var curWallet = wallets.FirstOrDefault(wal => wal == wallet);
            if (curWallet == null)
            {
                var id = wallet.Id;
                curWallet = new WalletDto()
                {
                    Id = wallet.Id,
                    Name = $"Someone's Wallet {id?.Substring(0, Math.Min(5, id?.Length ?? 0))}",
                    Owner = $"Someone {id?.Substring(0, Math.Min(5, id?.Length ?? 0))}",
                    Paid = rand.NextDouble(),
                    Last24HoursReward = rand.Next(100, 999) / 10000.0,
                    UnconfirmedBalance = rand.Next(100, 200) / 1000000.0,
                    UnpaidBalance = rand.NextDouble() % paymentInterval,
                    Workers = new List<WorkerDto>()
                    {
                        new WorkerDto()
                        {
                            Name = $"Some worker {rand.Next(1,10)}",
                            CurrentHashRate = rand.Next(20,50),
                            HashRateLastHour = rand.Next(20,50),
                            LastShareInMinutes = rand.Next(0,60)
                        },
                        new WorkerDto()
                        {
                            Name = $"Some worker {rand.Next(1,10)}",
                            CurrentHashRate = rand.Next(20,50),
                            HashRateLastHour = rand.Next(20,50),
                            LastShareInMinutes = rand.Next(0,60)
                        },
                        new WorkerDto()
                        {
                            Name = $"Some worker {rand.Next(1,10)}",
                            CurrentHashRate = rand.Next(20,50),
                            HashRateLastHour = rand.Next(20,50),
                            LastShareInMinutes = rand.Next(0,60)
                        }
                    }
                };
                wallets.Add(curWallet);
            }
            return curWallet;
        }

        public async Task<IEnumerable<WalletDto>> GetWalletsAsync(HttpClient client, params WalletDto[]? wallets)
        {
            await Task.CompletedTask;
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