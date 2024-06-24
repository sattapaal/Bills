namespace Bills.Models
{


    public class Amendments
    {
        public List<Amendment> items { get; set; }
        public int totalResults { get; set; }
        public int itemsPerPage { get; set; }
    }
}
