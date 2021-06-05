using System;
using CryptoDashboardBlazor.Data.Store.Features.Wallet.Actions.LoadWalletsById;
using CryptoDashboardBlazor.Data.Store.State;
using Fluxor;

namespace CryptoDashboardBlazor.Data.Store.Features.Wallet.Reducers
{
    public class LoadWalletsByIdActionsReducer
    {
        [ReducerMethod(typeof(LoadWalletsByIdAction))]
        public static WalletState ReduceLoadWalletsByIdAction(WalletState state) =>
            state with
            {
                IsLoading = true,
                CurrentErrorMessage = null,
            };

        [ReducerMethod]
        public static WalletState ReduceLoadWalletsByIdSuccessAction(WalletState state, LoadWalletsByIdSuccessAction action) =>
            state with
            {
                CurrentWallets = action.Wallets,
                IsLoading = false,
                CurrentErrorMessage = null,
                LastUpdate = DateTime.Now
            };

        [ReducerMethod]
        public static WalletState ReduceLoadWalletsByIdFailureAction(WalletState state, LoadWalletsByIdFailureAction action) =>
            state with
            {
                IsLoading = false,
                CurrentErrorMessage = action.ErrorMessage,
            };
    }
}
