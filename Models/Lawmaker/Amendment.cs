using System.Xml.Serialization;

namespace Lawmaker.Models.XML
{
// using System.Xml.Serialization;
// XmlSerializer serializer = new XmlSerializer(typeof(Amendment));
// using (StringReader reader = new StringReader(xml))
// {
//    var test = (Amendment)serializer.Deserialize(reader);
// }

[XmlRoot(ElementName="FRBRthis")]
public class FRBRthis { 
	//[XmlIgnore]
	[XmlAttribute(AttributeName="value")] 
	public string Value { get; set; } 
}

[XmlRoot(ElementName="FRBRuri")]
public class FRBRuri { 

	[XmlAttribute(AttributeName="value")] 
	public string Value { get; set; } 
}

[XmlRoot(ElementName="FRBRalias")]
public class FRBRalias { 

	[XmlAttribute(AttributeName="name")] 
	public string Name { get; set; } 

	[XmlAttribute(AttributeName="value")] 
	public string Value { get; set; } 
}

[XmlRoot(ElementName="FRBRdate")]
public class FRBRdate { 

	[XmlAttribute(AttributeName="date")] 
	public DateTime Date { get; set; } 

	[XmlAttribute(AttributeName="name")] 
	public string Name { get; set; } 
}

[XmlRoot(ElementName="FRBRauthor")]
public class FRBRauthor { 

	[XmlAttribute(AttributeName="href")] 
	public string Href { get; set; } 
}

[XmlRoot(ElementName="FRBRcountry")]
public class FRBRcountry { 

	[XmlAttribute(AttributeName="value")] 
	public string Value { get; set; } 
}

[XmlRoot(ElementName="FRBRnumber")]
public class FRBRnumber { 

	[XmlAttribute(AttributeName="value")] 
	public string Value { get; set; } 
}

[XmlRoot(ElementName="FRBRWork")]
public class FRBRWork { 
	//[XmlIgnore]
	[XmlElement(ElementName="FRBRthis")] 
	public FRBRthis FRBRthis { get; set; } 

	[XmlElement(ElementName="FRBRuri")] 
	public FRBRuri FRBRuri { get; set; } 

	[XmlElement(ElementName="FRBRalias")] 
	public FRBRalias FRBRalias { get; set; } 

	[XmlElement(ElementName="FRBRdate")] 
	public FRBRdate FRBRdate { get; set; } 

	[XmlElement(ElementName="FRBRauthor")] 
	public FRBRauthor FRBRauthor { get; set; } 

	[XmlElement(ElementName="FRBRcountry")] 
	public FRBRcountry FRBRcountry { get; set; } 

	[XmlElement(ElementName="FRBRnumber")] 
	public FRBRnumber FRBRnumber { get; set; } 
}

[XmlRoot(ElementName="FRBRlanguage")]
public class FRBRlanguage { 

	[XmlAttribute(AttributeName="language")] 
	public string Language { get; set; } 
}

[XmlRoot(ElementName="FRBRExpression")]
public class FRBRExpression { 
	//[XmlIgnore]
	[XmlElement(ElementName="FRBRthis")] 
	public FRBRthis FRBRthis { get; set; } 

	[XmlElement(ElementName="FRBRuri")] 
	public FRBRuri FRBRuri { get; set; } 

	[XmlElement(ElementName="FRBRalias")] 
	public FRBRalias FRBRalias { get; set; } 

	[XmlElement(ElementName="FRBRdate")] 
	public FRBRdate FRBRdate { get; set; } 

	[XmlElement(ElementName="FRBRauthor")] 
	public FRBRauthor FRBRauthor { get; set; } 

	[XmlElement(ElementName="FRBRlanguage")] 
	public FRBRlanguage FRBRlanguage { get; set; } 
}

[XmlRoot(ElementName="FRBRformat")]
public class FRBRformat { 

	[XmlAttribute(AttributeName="value")] 
	public string Value { get; set; } 
}

[XmlRoot(ElementName="FRBRManifestation")]
public class FRBRManifestation { 
	//[XmlIgnore]
	[XmlElement(ElementName="FRBRthis")] 
	public FRBRthis FRBRthis { get; set; } 

	[XmlElement(ElementName="FRBRuri")] 
	public FRBRuri FRBRuri { get; set; } 

	[XmlElement(ElementName="FRBRdate")] 
	public FRBRdate FRBRdate { get; set; } 

	[XmlElement(ElementName="FRBRauthor")] 
	public FRBRauthor FRBRauthor { get; set; } 

	[XmlElement(ElementName="FRBRformat")] 
	public FRBRformat FRBRformat { get; set; } 
}

[XmlRoot(ElementName="identification")]
public class Identification { 

	[XmlElement(ElementName="FRBRWork")] 
	public FRBRWork FRBRWork { get; set; } 

	[XmlElement(ElementName="FRBRExpression")] 
	public FRBRExpression FRBRExpression { get; set; } 

	[XmlElement(ElementName="FRBRManifestation")] 
	public FRBRManifestation FRBRManifestation { get; set; } 

	[XmlAttribute(AttributeName="source")] 
	public string Source { get; set; } 
}

[XmlRoot(ElementName="step")]
public class Step { 

	[XmlAttribute(AttributeName="GUID")] 
	public string GUID { get; set; } 

	[XmlAttribute(AttributeName="by")] 
	public string By { get; set; } 

	[XmlAttribute(AttributeName="date")] 
	public DateTime Date { get; set; } 

	[XmlAttribute(AttributeName="eId")] 
	public string EId { get; set; } 

	[XmlAttribute(AttributeName="outcome")] 
	public string Outcome { get; set; } 

	[XmlAttribute(AttributeName="href")] 
	public string Href { get; set; } 

	[XmlAttribute(AttributeName="refersTo")] 
	public string RefersTo { get; set; } 
}

[XmlRoot(ElementName="workflow")]
public class Workflow { 

	[XmlElement(ElementName="step")] 
	public List<Step> Step { get; set; } 

	[XmlAttribute(AttributeName="source")] 
	public string Source { get; set; } 
}

[XmlRoot(ElementName="TLCPerson")]
public class TLCPerson { 

	[XmlAttribute(AttributeName="GUID")] 
	public string GUID { get; set; } 

	[XmlAttribute(AttributeName="eId")] 
	public string EId { get; set; } 

	[XmlAttribute(AttributeName="href")] 
	public string Href { get; set; } 

	[XmlAttribute(AttributeName="showAs")] 
	public string ShowAs { get; set; } 

	[XmlAttribute(AttributeName="class")] 
	public string Class { get; set; } 
}

[XmlRoot(ElementName="references")]
public class References { 

	[XmlElement(ElementName="TLCPerson")] 
	public TLCPerson TLCPerson { get; set; } 

	[XmlAttribute(AttributeName="source")] 
	public string Source { get; set; } 
}

[XmlRoot(ElementName="meta")]
public class Meta { 

	[XmlElement(ElementName="identification")] 
	public Identification Identification { get; set; } 

	[XmlElement(ElementName="workflow")] 
	public Workflow Workflow { get; set; } 

	[XmlElement(ElementName="references")] 
	public References References { get; set; } 
}

[XmlRoot(ElementName="ref")]
public class Ref { 

	[XmlAttribute(AttributeName="class")] 
	public string Class { get; set; } 

	[XmlAttribute(AttributeName="href")] 
	public string Href { get; set; } 

	[XmlText] 
	public string Text { get; set; } 
}

[XmlRoot(ElementName="affectedDocument")]
public class AffectedDocument { 

	[XmlElement(ElementName="ref")] 
	public Ref Ref { get; set; } 

	[XmlAttribute(AttributeName="href")] 
	public string Href { get; set; } 
}

[XmlRoot(ElementName="block")]
public class Block { 

	[XmlElement(ElementName="mod")] 
	public Mod Mod { get; set; } 

	[XmlElement(ElementName="affectedDocument")] 
	public AffectedDocument AffectedDocument { get; set; } 

	[XmlElement(ElementName="docStage")] 
	public string DocStage { get; set; } 

	[XmlAttribute(AttributeName="name")] 
	public string Name { get; set; } 

	[XmlText] 
	public string Text { get; set; } 

	[XmlElement(ElementName="docIntroducer")] 
	public DocIntroducer DocIntroducer { get; set; } 

	[XmlElement(ElementName="ref")] 
	public Ref Ref { get; set; } 
}

[XmlRoot(ElementName="preface")]
public class Preface { 

	[XmlElement(ElementName="block")] 
	public Block Block { get; set; } 

	[XmlAttribute(AttributeName="GUID")] 
	public string GUID { get; set; } 

	[XmlAttribute(AttributeName="eId")] 
	public string EId { get; set; } 

	[XmlText] 
	public string Text { get; set; } 
}

[XmlRoot(ElementName="docIntroducer")]
public class DocIntroducer { 

	[XmlAttribute(AttributeName="refersTo")] 
	public string RefersTo { get; set; } 

	[XmlText] 
	public string Text { get; set; } 
}

[XmlRoot(ElementName="amendmentHeading")]
public class AmendmentHeading { 

	[XmlElement(ElementName="block")] 
	public List<Block> Block { get; set; } 

	[XmlAttribute(AttributeName="GUID")] 
	public string GUID { get; set; } 

	[XmlAttribute(AttributeName="eId")] 
	public string EId { get; set; } 

	[XmlText] 
	public string Text { get; set; } 
}

[XmlRoot(ElementName="num")]
public class Num { 

	[XmlAttribute(AttributeName="dnum")] 
	public string Dnum { get; set; } 

	[XmlText] 
	public int Text { get; set; } 
}

[XmlRoot(ElementName="tblock")]
public class Tblock { 

	[XmlElement(ElementName="num")] 
	public Num Num { get; set; } 

	[XmlElement(ElementName="block")] 
	public Block Block { get; set; } 
}

[XmlRoot(ElementName="amendmentContent")]
public class AmendmentContent { 

	[XmlElement(ElementName="tblock")] 
	public Tblock Tblock { get; set; } 

	[XmlAttribute(AttributeName="GUID")] 
	public string GUID { get; set; } 

	[XmlAttribute(AttributeName="eId")] 
	public string EId { get; set; } 

	[XmlText] 
	public string Text { get; set; } 
}


[XmlRoot(ElementName="blockContainer")]
public class BlockContainer { 

	[XmlElement(ElementName="heading")] 
	public Heading Heading { get; set; } 

	[XmlElement(ElementName="p")] 
	public string P { get; set; } 

	[XmlAttribute(AttributeName="class")] 
	public string Class { get; set; } 

	[XmlText] 
	public string Text { get; set; } 
}

[XmlRoot(ElementName="amendmentJustification")]
public class AmendmentJustification { 

	[XmlElement(ElementName="blockContainer")] 
	public BlockContainer BlockContainer { get; set; } 
}

[XmlRoot(ElementName="amendmentBody")]
public class AmendmentBody { 

	[XmlElement(ElementName="amendmentHeading")] 
	public AmendmentHeading AmendmentHeading { get; set; } 

	[XmlElement(ElementName="amendmentContent")] 
	public AmendmentContent AmendmentContent { get; set; } 

	[XmlElement(ElementName="amendmentJustification")] 
	public AmendmentJustification AmendmentJustification { get; set; } 

	[XmlAttribute(AttributeName="GUID")] 
	public string GUID { get; set; } 

	[XmlAttribute(AttributeName="eId")] 
	public string EId { get; set; } 

	[XmlAttribute(AttributeName="location")] 
	public string Location { get; set; } 

	[XmlAttribute(AttributeName="memberInCharge")] 
	public string MemberInCharge { get; set; } 

	[XmlAttribute(AttributeName="targetPage")] 
	public string TargetPage { get; set; } 

	[XmlAttribute(AttributeName="targetProvision")] 
	public string TargetProvision { get; set; } 

	[XmlAttribute(AttributeName="type")] 
	public string Type { get; set; } 

	[XmlText] 
	public string Text { get; set; } 
}

[XmlRoot(ElementName="amendment")]
public class Amendment { 

	[XmlElement(ElementName="meta")] 
	public Meta Meta { get; set; } 

	[XmlElement(ElementName="preface")] 
	public Preface Preface { get; set; } 

	[XmlElement(ElementName="amendmentBody")] 
	public AmendmentBody AmendmentBody { get; set; } 

	[XmlAttribute(AttributeName="ukl")] 
	public string Ukl { get; set; } 

	[XmlAttribute(AttributeName="xsi")] 
	public string Xsi { get; set; } 

	[XmlAttribute(AttributeName="name")] 
	public string Name { get; set; } 

	[XmlText] 
	public string Text { get; set; } 
}


[XmlRoot(ElementName="heading")]
public class Heading { 

	[XmlAttribute(AttributeName="GUID")] 
	public string GUID { get; set; } 

	[XmlAttribute(AttributeName="eId")] 
	public string EId { get; set; } 

	[XmlText] 
	public string Text { get; set; } 
}

[XmlRoot(ElementName="content")]
public class Content { 

	[XmlElement(ElementName="p")] 
	public string P { get; set; } 

	[XmlElement(ElementName="blockList")] 
	public BlockList BlockList { get; set; } 
}

[XmlRoot(ElementName="subsection")]
public class Subsection { 

	[XmlElement(ElementName="num")] 
	public string Num { get; set; } 

	[XmlElement(ElementName="content")] 
	public Content Content { get; set; } 

	[XmlAttribute(AttributeName="GUID")] 
	public string GUID { get; set; } 

	[XmlAttribute(AttributeName="class")] 
	public string Class { get; set; } 

	[XmlAttribute(AttributeName="eId")] 
	public string EId { get; set; } 

	[XmlText] 
	public string Text { get; set; } 

	[XmlElement(ElementName="intro")] 
	public Intro Intro { get; set; } 

	[XmlElement(ElementName="level")] 
	public List<Level> Level { get; set; } 
}

[XmlRoot(ElementName="intro")]
public class Intro { 

	[XmlElement(ElementName="p")] 
	public string P { get; set; } 

	[XmlAttribute(AttributeName="GUID")] 
	public string GUID { get; set; } 

	[XmlAttribute(AttributeName="eId")] 
	public string EId { get; set; } 

	[XmlText] 
	public string Text { get; set; } 
}

[XmlRoot(ElementName="level")]
public class Level { 

	[XmlElement(ElementName="num")] 
	public string Num { get; set; } 

	[XmlElement(ElementName="content")] 
	public Content Content { get; set; } 

	[XmlAttribute(AttributeName="GUID")] 
	public string GUID { get; set; } 

	[XmlAttribute(AttributeName="class")] 
	public string Class { get; set; } 

	[XmlAttribute(AttributeName="eId")] 
	public string EId { get; set; } 

	[XmlText] 
	public string Text { get; set; } 
}

[XmlRoot(ElementName="item")]
public class Item { 

	[XmlElement(ElementName="p")] 
	public P P { get; set; } 

	[XmlAttribute(AttributeName="GUID")] 
	public string GUID { get; set; } 

	[XmlAttribute(AttributeName="eId")] 
	public string EId { get; set; } 

	[XmlText] 
	public string Text { get; set; } 
}

[XmlRoot(ElementName="p")]
public class P { 

	[XmlElement(ElementName="i")] 
	public string I { get; set; } 
}

[XmlRoot(ElementName="blockList")]
public class BlockList { 

	[XmlElement(ElementName="item")] 
	public List<Item> Item { get; set; } 

	[XmlAttribute(AttributeName="GUID")] 
	public string GUID { get; set; } 

	[XmlAttribute(AttributeName="eId")] 
	public string EId { get; set; } 

	[XmlText] 
	public string Text { get; set; } 
}

[XmlRoot(ElementName="section")]
public class Section { 

	[XmlElement(ElementName="num")] 
	public object Num { get; set; } 

	[XmlElement(ElementName="heading")] 
	public Heading Heading { get; set; } 

	[XmlElement(ElementName="subsection")] 
	public List<Subsection> Subsection { get; set; } 

	[XmlAttribute(AttributeName="GUID")] 
	public string GUID { get; set; } 

	[XmlAttribute(AttributeName="class")] 
	public string Class { get; set; } 

	[XmlAttribute(AttributeName="eId")] 
	public string EId { get; set; } 

	[XmlText] 
	public string Text { get; set; } 
}

[XmlRoot(ElementName="quotedStructure")]
public class QuotedStructure { 

	[XmlElement(ElementName="section")] 
	public Section Section { get; set; } 

	[XmlAttribute(AttributeName="GUID")] 
	public string GUID { get; set; } 

	[XmlAttribute(AttributeName="eId")] 
	public string EId { get; set; } 

	[XmlAttribute(AttributeName="endQuote")] 
	public string EndQuote { get; set; } 

	[XmlAttribute(AttributeName="startQuote")] 
	public string StartQuote { get; set; } 

	[XmlAttribute(AttributeName="context")] 
	public string Context { get; set; } 

	[XmlAttribute(AttributeName="docName")] 
	public string DocName { get; set; } 

	[XmlAttribute(AttributeName="indent")] 
	public string Indent { get; set; } 

	[XmlText] 
	public string Text { get; set; } 
}

[XmlRoot(ElementName="inline")]
public class Inline { 

	[XmlAttribute(AttributeName="name")] 
	public string Name { get; set; } 
}

[XmlRoot(ElementName="mod")]
public class Mod { 

	[XmlElement(ElementName="quotedStructure")] 
	public QuotedStructure QuotedStructure { get; set; } 

	[XmlElement(ElementName="inline")] 
	public Inline Inline { get; set; } 
	
	[XmlText] 
	public string Text { get; set; } 
}


}