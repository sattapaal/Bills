namespace Bills.Models
{
    public class SearchBillAmendmentsViewModel
    {
        public Bills Bills { get; set; }

        public List<Stage> Stages { get; set; }

        public List<string> Decisions { get; set; }
    }
}
