using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoDashboardBlazor.Data.Models;
using CryptoDashboardBlazor.Data.Services;
using CryptoDashboardBlazor.Data.Store.State;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace CryptoDashboardBlazor.Client.Components
{
    public partial class Dashboard
    {
        [Inject]
        public IState<WalletState> WalletState { get; set; } = null!;

        [Inject] public HttpClient Client { get; set; } = null!;

        [Inject]
        public StateFacade Facade { get; set; } = null!;

        [Inject] public AppConfiguration Configuration { get; set; } = null!;

        public WalletDto? WalletsOverview
        {
            get
            {
                if (WalletState?.Value.CurrentWallets?.Any() != true)
                {
                    return null;
                }
                var wallet = new WalletDto
                {
                    Name = "Summary",
                    UnconfirmedBalance = WalletState.Value.CurrentWallets.Sum(wal => wal.UnconfirmedBalance),
                    UnpaidBalance = WalletState.Value.CurrentWallets.Sum(wal => wal.UnpaidBalance),
                    Paid = WalletState.Value.CurrentWallets.Sum(wal => wal.Paid),
                    Workers = WalletState.Value.CurrentWallets.SelectMany(wal => wal.Workers ?? Enumerable.Empty<WorkerDto>()),
                    Last24HoursReward = WalletState.Value.CurrentWallets.Sum(wal => wal.Last24HoursReward)
                };
                return wallet;
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (WalletState.Value.CurrentPoolInfo == null)
                {
                    LoadPoolInfo();
                }
                if (WalletState.Value.CurrentWallets?.Any() != true)
                {
                    LoadWallets();
                }
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        private void LoadWallets()
        {
            List<WalletDto> wallets = Configuration.Wallets?.ToList() ?? new List<WalletDto>();
            Facade.LoadWallets(wallets.ToArray());
        }

        private void LoadPoolInfo()
        {
            Facade.LoadPoolInfo(Configuration.PoolInfo?.Name, WalletState.Value.CurrentApiUrl);
        }
    }
}