using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SadeceGonderdigimKolonlariGuncelleme.DTO
{
    [DataContract]
    public class GrupDTO
    {
        public int Id { get; set; }

        [DataMember]
        public Guid Guid { get; set; }

        [DataMember]
        public string Ad { get; set; }
    }
}
