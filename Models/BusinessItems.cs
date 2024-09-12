namespace Bills.Models.OrderPaper
{
    public class BusinessItemDetail
    {
        public List<object> ChildDayItems { get; set; }
        public List<Sponsor> Sponsors { get; set; }
        public List<StandingOrder> StandingOrders { get; set; }
        public List<object> Amendments { get; set; }
        public List<object> Links { get; set; }
        public List<object> RenderedFields { get; set; }
        public string BusinessItemType { get; set; }
        public string Notes { get; set; }
        public object SponsorNotes { get; set; }
        public string Time { get; set; }
        public string Duration { get; set; }
        public string AdditionalInformation { get; set; }
        public DateTime? DateSubmitted { get; set; }
        public string RelevantDocuments { get; set; }
        public string ItemText { get; set; }
        public string AnsweringBodyName { get; set; }
    }

    public class ChildDayItems
    {
        public string DayItemType { get; set; }
        public int DayItemId { get; set; }
        public int TabledOrder { get; set; }
        public string Title { get; set; }
        public object Notes { get; set; }
        public BusinessItemDetail BusinessItemDetail { get; set; }
    }

    public class Day
    {
        public DateTime Date { get; set; }
        public List<Section> Sections { get; set; }
    }

    public class DayItem
    {
        public string DayItemType { get; set; }
        public int DayItemId { get; set; }
        public int TabledOrder { get; set; }
        public string Title { get; set; }
        public object Notes { get; set; }
        public BusinessItemDetail BusinessItemDetail { get; set; }
    }

    public class BusinessItems
    {
        public string House { get; set; }
        public string Type { get; set; }
        public List<Day> Days { get; set; }
        public object DayItems { get; set; }
        //public List<DayItem> DayItems { get; set; }
    }

    public class Section
    {
        public List<DayItem> DayItems { get; set; }
        public int SectionId { get; set; }
        public string Name { get; set; }
    }

    public class Sponsor
    {
        public int MemberId { get; set; }
        public int SortOrder { get; set; }
        public bool HasRelevantInterest { get; set; }
        public string Name { get; set; }
        public string LayingMinisterName { get; set; }
    }

    public class StandingOrder
    {
        public string Text { get; set; }
        public int SortOrder { get; set; }
    }
    public class OrderPaper
    {
        public string House { get; set; }
        public string Type { get; set; }
        public List<Day> Days { get; set; }
        public object DayItems { get; set; }
    }
}