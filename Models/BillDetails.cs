namespace Bills.Models
{


    public class BillDetails
    {
        public string longTitle { get; set; }
        public object summary { get; set; }
        public List<Sponsor> sponsors { get; set; }
        public List<object> promoters { get; set; }
        public object petitioningPeriod { get; set; }
        public object petitionInformation { get; set; }
        public object agent { get; set; }
        public int billId { get; set; }
        public string shortTitle { get; set; }
        public string currentHouse { get; set; }
        public string originatingHouse { get; set; }
        public DateTime lastUpdate { get; set; }
        public object billWithdrawn { get; set; }
        public bool isDefeated { get; set; }
        public int billTypeId { get; set; }
        public int introducedSessionId { get; set; }
        public List<int> includedSessionIds { get; set; }
        public bool isAct { get; set; }
        public CurrentStage currentStage { get; set; }
    }



}
