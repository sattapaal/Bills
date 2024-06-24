namespace Bills.Models
{


    public class BillStages
    {
        public List<BillStage> items { get; set; }
        public int totalResults { get; set; }
        public int itemsPerPage { get; set; }
    }
}
