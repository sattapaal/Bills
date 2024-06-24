namespace Bills.Models
{
    public class StageSitting
    {
        public int id { get; set; }
        public int stageId { get; set; }
        public int billStageId { get; set; }
        public int billId { get; set; }
        public DateTime date { get; set; }
    }
}
