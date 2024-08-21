namespace Lawmaker.Models
{
    public class Link
    {
        public string href { get; set; }
        public string manifestation { get; set; }
        public string method { get; set; }
    }

    public class Bill
    {
        public string title { get; set; }
        public string vdGuid { get; set; }
        public string label { get; set; }
        public string stage { get; set; }
        public DateTime publicationDate { get; set; }
        public string house { get; set; }
        public string docType { get; set; }
        public List<Link> _links { get; set; }
    }
}