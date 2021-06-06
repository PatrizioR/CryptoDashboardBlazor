using CryptoDashboardBlazor.Data.Models;
using CryptoDashboardBlazor.Data.Store.Features.Wallet.Actions.AddWalletAndSelect;
using CryptoDashboardBlazor.Data.Store.Features.Wallet.Actions.LoadPoolInfoByName;
using CryptoDashboardBlazor.Data.Store.Features.Wallet.Actions.LoadWalletsById;
using CryptoDashboardBlazor.Data.Store.Features.Wallet.Actions.SaveSettings;
using Fluxor;
using Microsoft.Extensions.Logging;

namespace CryptoDashboardBlazor.Data.Services
{
    public class StateFacade
    {
        private readonly ILogger<StateFacade> _logger;
        private readonly IDispatcher _dispatcher;

        public StateFacade(ILogger<StateFacade> logger, IDispatcher dispatcher) =>
            (_logger, _dispatcher) = (logger, dispatcher);

        public void LoadWallets(params WalletDto[] wallets)
        {
            _logger.LogInformation($"Issuing action to load wallets...");
            _dispatcher.Dispatch(new LoadWalletsByIdAction(wallets));
        }

        public void LoadPoolInfo(string? name, string? url)
        {
            _logger.LogInformation($"Issuing action to load pool info...");
            _dispatcher.Dispatch(new LoadPoolInfoByNameAction(name, url));
        }

        public void LoadPoolInfo(string name, string id, string url)
        {
            _logger.LogInformation($"Issuing action to load pool info...");
            _dispatcher.Dispatch(new LoadPoolInfoByNameAction($"{name};{id}", url));
        }

        public void SaveSettings(string? apiUrl, WalletDto? wallet)
        {
            _logger.LogInformation($"Issuing action to save settings...");
            _dispatcher.Dispatch(new SaveSettingsAction(apiUrl, wallet));
        }

        public void AddWalletAndSelect()
        {
            _logger.LogInformation($"Issuing action to create new wallet and select...");
            _dispatcher.Dispatch(new AddWalletAndSelectAction());
        }
    }
}