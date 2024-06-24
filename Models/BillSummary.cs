namespace Bills.Models
{
    public class BillSummary
    {
        public int BillId { get; set; }
        public string Name { get; set; }
        public string Stage { get; set; }

        public string Description { get; set; }
        public DateTime? DateModified { get; set; }
        
        public AmendmentCount AmendmentCount { get; set; }

        public List<Amendment> Amendments { get; set; }

        public List<AmendmentCount> AmendmentsByStage { get; set; }
    }

    public class AmendmentCount
    {
        public int NoDecision { get; set; }
        public int Agreed { get; set; }
        public int NotCalled { get; set; }
        public int NotMoved { get; set; }
        public int Withdrawn { get; set; }
        public int NegativedOnDivision { get; set; }

        public int NotSelected { get; set; }
        public string Stage { get; set; }
        public int AmendmentTotal { get; set; }
    }



}
