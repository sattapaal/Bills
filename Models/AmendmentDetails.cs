namespace Bills.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AmendmentLine
    {
        public string text { get; set; }
        public int indentation { get; set; }
        public string hangingIndentation { get; set; }
        public bool isImage { get; set; }
        public object imageType { get; set; }
    }

    public class AmendmentDetails
    {
        public List<AmendmentLine> amendmentLines { get; set; }
        public string explanatoryTextPrefix { get; set; }
        public string explanatoryText { get; set; }
        public object amendmentNote { get; set; }
        public string amendmentLocation { get; set; }
        public string mainHeader { get; set; }
        public int amendmentId { get; set; }
        public string amendmentType { get; set; }
        public object clause { get; set; }
        public object schedule { get; set; }
        public object pageNumber { get; set; }
        public object lineNumber { get; set; }
        public object amendmentPosition { get; set; }
        public string marshalledListText { get; set; }
        public int id { get; set; }
        public int billId { get; set; }
        public int billStageId { get; set; }
        public object statusIndicator { get; set; }
        public string decision { get; set; }
        public string decisionExplanation { get; set; }
        public List<Sponsor> sponsors { get; set; }
    }

    //public class Sponsor
    //{
    //    public bool isLead { get; set; }
    //    public int sortOrder { get; set; }
    //    public int memberId { get; set; }
    //    public string name { get; set; }
    //    public string party { get; set; }
    //    public string partyColour { get; set; }
    //    public string house { get; set; }
    //    public string memberPhoto { get; set; }
    //    public string memberPage { get; set; }
    //    public string memberFrom { get; set; }
    //}

}
