using System.Text.Json.Serialization;

namespace CryptoDashboardBlazor.Data.Models
{
    public class CryptocompareRequestDto
    {
        [JsonPropertyName("EUR")]
        public double? EUR { get; set; }
    }
}
