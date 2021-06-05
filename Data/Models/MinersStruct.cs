using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CryptoDashboardBlazor.Data.Models
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class MinerChart
    {
        [JsonPropertyName("minerHash")]
        public int MinerHash { get; set; }

        [JsonPropertyName("minerLargeHash")]
        public int MinerLargeHash { get; set; }

        [JsonPropertyName("timeFormat")]
        public string? TimeFormat { get; set; }

        [JsonPropertyName("workerOnline")]
        public int WorkerOnline { get; set; }

        [JsonPropertyName("x")]
        public int X { get; set; }
    }

    public class Payment
    {
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("timestamp")]
        public int Timestamp { get; set; }

        [JsonPropertyName("tx")]
        public string? Tx { get; set; }
    }

    public class Reward
    {
        [JsonPropertyName("blockheight")]
        public int Blockheight { get; set; }

        [JsonPropertyName("timestamp")]
        public int Timestamp { get; set; }

        [JsonPropertyName("reward")]
        public int RewardAmount { get; set; }

        [JsonPropertyName("percent")]
        public double Percent { get; set; }

        [JsonPropertyName("immature")]
        public bool Immature { get; set; }

        [JsonPropertyName("orphan")]
        public bool Orphan { get; set; }

        [JsonPropertyName("uncle")]
        public bool Uncle { get; set; }
    }

    public class Stats
    {
        [JsonPropertyName("balance")]
        public int Balance { get; set; }

        [JsonPropertyName("immature")]
        public int Immature { get; set; }

        [JsonPropertyName("lastShare")]
        public int LastShare { get; set; }

        [JsonPropertyName("paid")]
        public int Paid { get; set; }

        [JsonPropertyName("pending")]
        public int Pending { get; set; }
    }

    public class Sumreward
    {
        [JsonPropertyName("inverval")]
        public int Inverval { get; set; }

        [JsonPropertyName("reward")]
        public int Reward { get; set; }

        [JsonPropertyName("numreward")]
        public int Numreward { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("offset")]
        public int Offset { get; set; }
    }

    public partial class Worker
    {
        [JsonPropertyName("lastBeat")]
        public long LastBeat { get; set; }

        [JsonPropertyName("hr")]
        public long Hr { get; set; }

        [JsonPropertyName("offline")]
        public bool Offline { get; set; }

        [JsonPropertyName("hr2")]
        public long Hr2 { get; set; }
    }

    public class MinersStruct
    {
#pragma warning disable IDE1006 // Naming Styles
        [JsonPropertyName("24hnumreward")]
        public int _24hnumreward { get; set; }

        [JsonPropertyName("24hreward")]

        public int _24hreward { get; set; }
#pragma warning restore IDE1006 // Naming Styles

        [JsonPropertyName("currentHashrate")]
        public int CurrentHashrate { get; set; }

        [JsonPropertyName("currentLuck")]
        public string? CurrentLuck { get; set; }

        [JsonPropertyName("hashrate")]
        public int Hashrate { get; set; }

        [JsonPropertyName("minerCharts")]
        public List<MinerChart>? MinerCharts { get; set; }

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        [JsonPropertyName("payments")]
        public List<Payment>? Payments { get; set; }

        [JsonPropertyName("paymentsTotal")]
        public int PaymentsTotal { get; set; }

        [JsonPropertyName("rewards")]
        public List<Reward>? Rewards { get; set; }

        [JsonPropertyName("roundShares")]
        public int RoundShares { get; set; }

        [JsonPropertyName("stats")]
        public Stats? Stats { get; set; }

        [JsonPropertyName("sumrewards")]
        public List<Sumreward>? Sumrewards { get; set; }

        [JsonPropertyName("updatedAt")]
        public long UpdatedAt { get; set; }

        [JsonPropertyName("workers")]
        public Dictionary<string, Worker>? Workers { get; set; }

        [JsonPropertyName("workersOffline")]
        public int WorkersOffline { get; set; }

        [JsonPropertyName("workersOnline")]
        public int WorkersOnline { get; set; }

        [JsonPropertyName("workersTotal")]
        public int WorkersTotal { get; set; }
    }


}
