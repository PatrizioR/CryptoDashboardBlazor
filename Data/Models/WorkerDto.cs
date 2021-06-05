namespace CryptoDashboardBlazor.Data.Models
{
    public enum OnlineStatus
    {
        None,
        Online,
        Unsure,
        Offline
    }
    public class WorkerDto
    {
        public double CurrentHashRate { get; set; }
        public double HashRateLastHour { get; set; }
        public double? LastShareInMinutes { get; set; }
        public string? Name { get; set; }
        public OnlineStatus Status
        {
            get
            {
                if(LastShareInMinutes < 10)
                {
                    return OnlineStatus.Online;
                }

                if(LastShareInMinutes < 30)
                {
                    return OnlineStatus.Unsure;
                }

                return OnlineStatus.Offline;
            }
        }
        
    }
}
