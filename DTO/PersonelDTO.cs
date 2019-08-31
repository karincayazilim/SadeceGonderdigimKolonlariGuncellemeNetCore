using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SadeceGonderdigimKolonlariGuncelleme.DTO
{
    [DataContract]
    public class PersonelDTO
    {
        public int Id { get; set; }

        [DataMember]
        public Guid Guid { get; set; }

        [DataMember]
        public string Ad { get; set; }

        [DataMember]
        public string Soyad { get; set; }

        [DataMember]
        public int CinsiyetId { get; set; }

        [DataMember]
        public int? UyrukId { get; set; }

        [DataMember]
        public List<GrupDTO> Gruplar { get; set; }

    }
}
