namespace Bills.Models
{
    public class CurrentStage
    {
        public int id { get; set; }
        public int stageId { get; set; }
        public int sessionId { get; set; }
        public string? description { get; set; }
        public string? abbreviation { get; set; }
        public string? house { get; set; }
        public List<StageSitting>? stageSittings { get; set; }
        public int sortOrder { get; set; }
    }
}
