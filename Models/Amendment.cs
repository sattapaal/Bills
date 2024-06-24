namespace Bills.Models
{
    public class Amendment
    {
        public List<string> summaryText { get; set; }
        public int amendmentId { get; set; }
        public string amendmentType { get; set; }
        public int? clause { get; set; }
        public object schedule { get; set; }
        public int? pageNumber { get; set; }
        public int? lineNumber { get; set; }
        public string amendmentPosition { get; set; }
        public string marshalledListText { get; set; }
        public int id { get; set; }
        public int billId { get; set; }
        public int billStageId { get; set; }
        public object statusIndicator { get; set; }
        public string decision { get; set; }
        public string decisionExplanation { get; set; }
        public List<Sponsor> sponsors { get; set; }

        public string stageName { get; set; }
    }
}
