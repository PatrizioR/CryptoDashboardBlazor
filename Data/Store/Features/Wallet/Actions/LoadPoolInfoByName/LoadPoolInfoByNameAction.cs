namespace CryptoDashboardBlazor.Data.Store.Features.Wallet.Actions.LoadPoolInfoByName
{
    public record LoadPoolInfoByNameAction
    {
        public LoadPoolInfoByNameAction(string? name, string? url) => (Name, Url) = (name, url);
        public string? Name { get; init; }
        public string? Url { get; init; }
    }
}