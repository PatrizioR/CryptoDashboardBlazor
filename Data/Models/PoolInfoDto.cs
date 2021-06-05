using System;
using System.ComponentModel.DataAnnotations;
using CryptoDashboardBlazor.Data.Extensions;

namespace CryptoDashboardBlazor.Data.Models
{
    public class PoolInfoDto
    {
        [Required]
        public string Name { get; set; } = null!;

        public double PaymentInterval { get; set; }
        public string? PaymentFormatted => (PaymentInterval * CoinInfo?.Exchange).ToRoundedString();
        public CoinInfoDto? CoinInfo { get; set; }

        public DateTime? NextPayment(double? currentBalance, double? last24hoursRewards)
        {
            if (!currentBalance.HasValue || !last24hoursRewards.HasValue)
            {
                return null;
            }

            if (PaymentInterval < currentBalance)
            {
                return DateTime.Now;
            }

            var missingReward = PaymentInterval - currentBalance.Value;

            var missingDays = Math.Round(missingReward / last24hoursRewards.Value, 5);

            if (missingDays > 365)
            {
                // too much
                return null;
            }
            var nextPaymentEstimated = DateTime.Now.AddDays(missingDays);

            return nextPaymentEstimated;
        }

        public static string AccountUrl(string urlTemplate, string id)
        {
            return urlTemplate.Replace("%1", id);
        }
    }
}