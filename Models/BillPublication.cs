namespace Bills.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class File
    {
        public int id { get; set; }
        public string filename { get; set; }
        public string contentType { get; set; }
        public int contentLength { get; set; }
    }

    public class Link
    {
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string contentType { get; set; }
    }

    public class Publication
    {
        public string house { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public PublicationType publicationType { get; set; }
        public DateTime displayDate { get; set; }
        public List<Link> links { get; set; }
        public List<File> files { get; set; }
    }

    public class PublicationType
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class BillPublication
    {
        public int billId { get; set; }
        public List<Publication> publications { get; set; }
    }

}
