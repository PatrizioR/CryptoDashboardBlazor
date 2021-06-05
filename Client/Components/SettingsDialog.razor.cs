using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazored.Modal;
using Blazored.Modal.Services;
using Blazored.Toast.Services;
using CryptoDashboardBlazor.Data.Models;
using CryptoDashboardBlazor.Data.Services;
using CryptoDashboardBlazor.Data.Store.State;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace CryptoDashboardBlazor.Client.Components
{
    public partial class SettingsDialog
    {
        [CascadingParameter] public IModalService Modal { get; set; } = null!;
        [CascadingParameter] private BlazoredModalInstance BlazoredModal { get; set; } = null!;
        [Inject] public IState<WalletState> WalletState { get; set; } = null!;
        [Inject] public StateFacade Facade { get; set; } = null!;
        [Inject] private ILocalStorageService LocalStorage { get; set; } = null!;
        [Inject] private IToastService ToastService { get; set; } = null!;
        public WalletDto EditItem => WalletState.Value.CurrentWallet;

        public string? CurrentPoolInfoUrl { get; set; }

        protected override async Task OnInitializedAsync()
        {
            CurrentPoolInfoUrl = await LocalStorage.GetItemAsync<string>("PoolInfoUrl");
            await base.OnInitializedAsync();
        }

        public async Task SaveAsync()
        {
            // save
            await BlazoredModal.CloseAsync();

            await LocalStorage.SetItemAsync("PoolInfoUrl", CurrentPoolInfoUrl);
            Facade.SaveSettings(CurrentPoolInfoUrl);
        }
    }
}