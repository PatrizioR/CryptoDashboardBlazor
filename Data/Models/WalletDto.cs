using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CryptoDashboardBlazor.Data.Models
{
    public class WalletDto
    {
        [Key]
        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? Owner { get; set; }
        public double? UnpaidBalance { get; set; }
        public double? UnconfirmedBalance { get; set; }
        public double? Balance { get; set; }
        public double? Paid { get; set; }
        public double? Last24HoursReward { get; set; }
        public IEnumerable<WorkerDto>? Workers { get; set; }
        public double CurrentHashRate => Workers?.Any() == true ? Workers.Sum(worker => worker.CurrentHashRate) : 0;
    }
}