using CryptoDashboardBlazor.Data.Store.Features.Wallet.Actions.LoadPoolInfoByName;
using CryptoDashboardBlazor.Data.Store.State;
using Fluxor;

namespace CryptoDashboardBlazor.Data.Store.Features.Wallet.Reducers
{
    public class LoadPoolInfoByNameActionsReducer
    {
        [ReducerMethod(typeof(LoadPoolInfoByNameAction))]
        public static WalletState ReduceLoadPoolInfoByNameAction(WalletState state) =>
            state with
            {
                CurrentPoolInfo = null,
                IsLoading = true,
                CurrentErrorMessage = null,
            };

        [ReducerMethod]
        public static WalletState ReduceLoadPoolInfoByNameSuccessAction(WalletState state, LoadPoolInfoByNameSuccessAction action) =>
            state with
            {
                CurrentPoolInfo = action.PoolInfo,
                IsLoading = false,
                CurrentErrorMessage = null,
            };

        [ReducerMethod]
        public static WalletState ReduceLoadPoolInfoByNameFailureAction(WalletState state, LoadPoolInfoByNameFailureAction action) =>
            state with
            {
                IsLoading = false,
                CurrentErrorMessage = action.ErrorMessage,
            };
    }
}
