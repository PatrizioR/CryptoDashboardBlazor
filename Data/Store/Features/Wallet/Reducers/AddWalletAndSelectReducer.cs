using Fluxor;
using CryptoDashboardBlazor.Data.Store.Features.Wallet.Actions.AddWalletAndSelect;
using CryptoDashboardBlazor.Data.Store.State;

namespace CryptoDashboardBlazor.Data.Store.Features.Wallet.Reducers
{
    public class AddWalletAndSelectActionsReducer
    {
        [ReducerMethod(typeof(AddWalletAndSelectAction))]
        public static WalletState ReduceAddWalletAndSelectAction(WalletState state) =>
            state with
            {
                IsLoading = true,
                CurrentErrorMessage = null,
            };

        [ReducerMethod]
        public static WalletState ReduceAddWalletAndSelectSuccessAction(WalletState state, AddWalletAndSelectSuccessAction action) =>
            state with
            {
                IsLoading = false,
                CurrentErrorMessage = null,
                CurrentWallet = action.Wallet
            };

        [ReducerMethod]
        public static WalletState ReduceAddWalletAndSelectFailureAction(WalletState state, AddWalletAndSelectFailureAction action) =>
            state with
            {
                IsLoading = false,
                CurrentErrorMessage = action.ErrorMessage,
            };
    }
}