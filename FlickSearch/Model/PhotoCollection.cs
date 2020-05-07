using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FlickrSearch.Model
{
    [DataContract]
    public class PhotoCollection
    {
        [XmlAttribute(AttributeName = "page")]
        [DataMember]
        public int page;

        [DataMember]
        [XmlAttribute(AttributeName = "pages")]
        public int pages;

        [DataMember]
        [XmlAttribute(AttributeName = "perpage")]
        public int perpage;

        [DataMember]
        [XmlAttribute(AttributeName = "total")]
        public int total;

        [DataMember]
        [XmlElement(ElementName = "photo")]
        public Collection<Photo> photo;
    }
}
