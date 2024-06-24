namespace Bills.Models
{
    public class Bill
    {
        public int billId { get; set; }
        public string ?shortTitle { get; set; }
        public string? currentHouse { get; set; }
        public string? originatingHouse { get; set; }
        public DateTime? lastUpdate { get; set; }
        public object? billWithdrawn { get; set; }
        public bool isDefeated { get; set; }
        public int? billTypeId { get; set; }
        public int? introducedSessionId { get; set; }
        public List<int>? includedSessionIds { get; set; }
        public bool isAct { get; set; }
        public CurrentStage? currentStage { get; set; }
    }
}
