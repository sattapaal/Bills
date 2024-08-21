namespace Lawmaker.Models
{
    public class Result
    {
        public string projectId { get; set; }
        public string chGuid { get; set; }
        public string docType { get; set; }
        public string docLabel { get; set; }
        public string title { get; set; }
    }

    public class LawmakerBillList
    {
        public List<Result> result { get; set; }
        public int total { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
    }
}