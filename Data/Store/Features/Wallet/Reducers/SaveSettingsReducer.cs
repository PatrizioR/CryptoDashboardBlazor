using Fluxor;
using CryptoDashboardBlazor.Data.Store.Features.Wallet.Actions.SaveSettings;
using CryptoDashboardBlazor.Data.Store.State;

namespace CryptoDashboardBlazor.Data.Store.Features.Wallet.Reducers
{
    public class SaveSettingsActionsReducer
    {
        [ReducerMethod(typeof(SaveSettingsAction))]
        public static WalletState ReduceSaveSettingsAction(WalletState state) =>
            state with
        {
            IsLoading = true,
            CurrentErrorMessage = null,
        };

        [ReducerMethod]
        public static WalletState ReduceSaveSettingsSuccessAction(WalletState state, SaveSettingsSuccessAction action) =>
            state with
        {
            IsLoading = false,
            CurrentErrorMessage = null,
        };

        [ReducerMethod]
        public static WalletState ReduceSaveSettingsFailureAction(WalletState state, SaveSettingsFailureAction action) =>
            state with
        {
            IsLoading = false,
            CurrentErrorMessage = action.ErrorMessage,
        };
    }
}
