using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FlickrSearch.Model
{
    [DataContract]
    [XmlRoot("rsp")]
    public class FlickrSearchResponse
    {
        [DataMember]
        [XmlAttribute(AttributeName = "stat")]
        public string stat;

        [DataMember]
        [XmlElement(ElementName = "photos")]
        public PhotoCollection photos;

        [DataMember]
        [XmlAttribute(AttributeName = "code")]
        public string code;

        [DataMember]
        [XmlAttribute(AttributeName = "message")]
        public string message;
    }
}
