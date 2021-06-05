using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.Modal.Services;
using Blazored.Toast.Services;
using Blazorise;
using CryptoDashboardBlazor.Client.Components;
using CryptoDashboardBlazor.Data.Services;
using CryptoDashboardBlazor.Data.Store.State;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace CryptoDashboardBlazor.Client.Shared
{
    public partial class MainLayout
    {
        [Inject] public IState<WalletState> ComponentsState { get; set; } = null!;
        [Inject] public StateFacade Facade { get; set; } = null!;
        [Inject] private IToastService ToastService { get; set; } = null!;
        [CascadingParameter] public IModalService Modal { get; set; } = null!;

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender && ComponentsState.Value.CurrentApiUrl == null)
            {
                ComponentsState.StateChanged += ComponentsState_StateChanged;
            }
        }

        private void ComponentsState_StateChanged(object? sender, WalletState e)
        {
            if (!e.IsLoading && e.CurrentApiUrl != null)
            {
                Modal.Show<SettingsDialog>($"Settings", new Blazored.Modal.ModalOptions() { ContentScrollable = true });
            }

            if (!e.IsLoading && e.HasCurrentErrors)
            {
                ToastService.ShowError(e.CurrentErrorMessage, "Fehler");
            }
        }
    }
}