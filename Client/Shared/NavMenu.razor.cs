using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazored.Modal.Services;
using Blazored.Toast.Services;
using CryptoDashboardBlazor.Client.Components;
using CryptoDashboardBlazor.Data.Models;
using CryptoDashboardBlazor.Data.Services;
using CryptoDashboardBlazor.Data.Store.State;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CryptoDashboardBlazor.Client.Shared
{
    public partial class NavMenu
    {
        [Inject] public IState<WalletState> ComponentsState { get; set; } = null!;
        [Inject] public StateFacade Facade { get; set; } = null!;
        [Inject] private IToastService ToastService { get; set; } = null!;
        [CascadingParameter] public IModalService Modal { get; set; } = null!;

        [Inject]
        public IState<WalletState> WalletState { get; set; } = null!;

        [Inject] public HttpClient Client { get; set; } = null!;

        [Inject] public AppConfiguration Configuration { get; set; } = null!;
        [Inject] private ILocalStorageService LocalStorage { get; set; } = null!;

        public async Task AddWalletAndShowSettingsAsync()
        {
            Facade.AddWalletAndSelect();
            await ShowSettingsAsync();
        }

        public async Task ShowSettingsAsync()
        {
            Modal.Show<SettingsDialog>($"Settings", new Blazored.Modal.ModalOptions() { HideHeader = true });
        }

        private async Task LoadWalletsAsync()
        {
            List<WalletDto> wallets = Configuration.Wallets?.ToList() ?? new List<WalletDto>();

            var currentWallet = await LocalStorage.GetItemAsync<WalletDto>(AppConfiguration.WalletLabel);

            if (currentWallet != null)
            {
                wallets.Add(currentWallet);
            }

            Facade.LoadWallets(wallets.ToArray());
        }

        private async Task LoadPoolInfoAsync()
        {
            var currentPoolInfoUrl = await LocalStorage.GetItemAsync<string>(AppConfiguration.ApiKeyLabel);

            Facade.LoadPoolInfo(Configuration.PoolInfo?.Name, Configuration.EthereumPriceApiUrl?.Replace(AppConfiguration.ApiKeyLabel, currentPoolInfoUrl ?? ""));
        }

        private readonly CultureInfo[] supportedCultures = new[]
        {
            new CultureInfo("en-GB"),
            new CultureInfo("de-DE"),
        };

        private CultureInfo Culture
        {
            get => CultureInfo.CurrentCulture;
            set
            {
                if (CultureInfo.CurrentCulture != value)
                {
                    switch (JSRuntime)
                    {
                        case IJSInProcessRuntime jsClient:
                            jsClient.InvokeVoid("blazorCulture.set", value.Name);
                            Nav.NavigateTo(Nav.Uri, forceLoad: true);
                            break;

                        case IJSRuntime jsServer:
#pragma warning disable CA2012 // Use ValueTasks correctly
                            jsServer.InvokeVoidAsync("blazorCulture.set", value.Name);
#pragma warning restore CA2012 // Use ValueTasks correctly
                            Nav.NavigateTo(Nav.Uri, forceLoad: true);
                            break;

                        default:
                            CultureInfo.CurrentCulture = value;
                            StateHasChanged();
                            break;
                    }
                }
            }
        }
    }
}