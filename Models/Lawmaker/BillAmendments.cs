    namespace Lawmaker.Models
    {


    public class Amendment
    {
        public string advGuid { get; set; }
        public string amendmentNum { get; set; }
        public string version { get; set; }
        public string stage { get; set; }
        public string affectedDocument { get; set; }
        public string type { get; set; }
        public List<Link> _links { get; set; }
    }

        public class BillAmendments
        {
            public List<Amendment> result { get; set; }
            public int total { get; set; }
            public int limit { get; set; }
            public int offset { get; set; }
            public int count { get; set; }
        }
    }