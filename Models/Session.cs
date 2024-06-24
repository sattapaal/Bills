namespace Bills.Models
{
    public class Session
    {
        public int SessionId { get; set; }
        public string Number { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CommonsDescription { get; set; }
        public string LordsDescription { get; set; }
        public string SessionNumber { get; set; }
        public string ParliamentNumber { get; set; }
    }
}
