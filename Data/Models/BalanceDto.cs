using System.Text.Json.Serialization;

namespace CryptoDashboardBlazor.Data.Models
{
    public class BalanceDto
    {
        [JsonPropertyName("result")]
        public string? Result { get; set; }
    }
}
