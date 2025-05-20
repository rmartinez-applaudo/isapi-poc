using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace IsapiPoC.Models
{
    [XmlRoot("UserList", Namespace = "http://www.hikvision.com/ver20/XMLSchema")]
    public class UserList
    {
        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlElement("User")]
        public List<User> Users { get; set; }
    }

    [XmlType(Namespace = "http://www.hikvision.com/ver20/XMLSchema")]
    public class User
    {
        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("userName")]
        public string UserName { get; set; }

        [XmlElement("userLevel")]
        public string UserLevel { get; set; }
    }
}
