namespace Bills.Models
{




    public class Bills
    {
        public List<Bill>? items { get; set; }
        public int totalResults { get; set; }
        public int itemsPerPage { get; set; }
    }




}
