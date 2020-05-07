using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace FlickrSearch.Model
{
    [DataContract]
    public class Photo
    {
        [DataMember]
        [XmlAttribute("id")]
        public string id;

        [DataMember]
        [XmlAttribute("owner")]
        public string owner;

        [DataMember]
        [XmlAttribute("secret")]
        public string secret;

        [DataMember]
        [XmlAttribute("server")]
        public string server;

        [DataMember]
        [XmlAttribute("farm")]
        public int farm;

        [DataMember]
        [XmlAttribute("title")]
        public string title;

        [DataMember]
        [XmlAttribute("ispublic")]
        public int ispublic;

        [DataMember]
        [XmlAttribute("isfriend")]
        public int isfriend;

        [DataMember]
        [XmlAttribute("isfamily")]
        public int isfamily;
    }
}
