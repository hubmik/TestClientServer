using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService.DTO
{
    [DataContract]
    public class CharStatistic
    {
        [DataMember]
        public char Litera { get; set; }
        [DataMember]
        public double ProcentWystapien { get; set; }
    }
}