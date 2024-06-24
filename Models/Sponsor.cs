namespace Bills.Models
{
    public class Sponsor
    {
        public Member member { get; set; }

        public bool isLead { get; set; }
        public object organisation { get; set; }
        public int sortOrder { get; set; }
    }
}
