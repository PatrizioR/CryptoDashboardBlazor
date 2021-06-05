namespace CryptoDashboardBlazor.Data.Store.State
{
    public record RootState
    {
        public RootState(bool isLoading, string? currentErrorMessage) =>
            (IsLoading, CurrentErrorMessage) = (isLoading, currentErrorMessage);

        public bool IsLoading { get; init; }

        public string? CurrentErrorMessage { get; init; }

        public bool HasCurrentErrors => !string.IsNullOrWhiteSpace(CurrentErrorMessage);
    }
}