using System;
using System.Xml.Serialization;

namespace CustomerSystm.Domain.DTOModels.BaseDtos
{
    [XmlRoot(ElementName = "TCKimlikNoDogrulaResponse")]
    public class TCKimlikNoDogrulaResponse
    {

        [XmlElement(ElementName = "TCKimlikNoDogrulaResult")]
        public string TCKimlikNoDogrulaResult { get; set; }

        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Body")]
    public class Body
    {

        [XmlElement(ElementName = "TCKimlikNoDogrulaResponse")]
        public TCKimlikNoDogrulaResponse TCKimlikNoDogrulaResponse { get; set; }
    }

    [XmlRoot(ElementName = "Envelope")]
    public class Envelope
    {

        [XmlElement(ElementName = "Body")]
        public Body Body { get; set; }

        [XmlAttribute(AttributeName = "xsi")]
        public string Xsi { get; set; }

        [XmlAttribute(AttributeName = "xsd")]
        public string Xsd { get; set; }

        [XmlAttribute(AttributeName = "soap")]
        public string Soap { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}

