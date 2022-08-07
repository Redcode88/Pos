using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace POS.Models
{
    [DataContract]
    public class States
    {
        [DataMember(Name ="ID")]
        public int ID { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }
    }
}
