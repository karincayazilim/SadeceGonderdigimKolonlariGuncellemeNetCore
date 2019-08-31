using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SadeceGonderdigimKolonlariGuncelleme.DTO;

namespace SadeceGonderdigimKolonlariGuncelleme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private List<PersonelDTO> entities = null;
        public ValuesController()
        {
            this.entities = new List<PersonelDTO>();
            entities.Add(new PersonelDTO()
            {
                Id = 1,
                Guid = new Guid("813a19b9-6ffd-4637-b592-4b119a0d67b8"),
                Ad = "Ad1",
                Soyad = "Soyad2",
                CinsiyetId = 1,
                UyrukId = 2,
                Gruplar = new List<GrupDTO>()
                {
                    new GrupDTO()
                    {
                        Id=1,
                        Guid = new Guid("fbabfe74-3ade-4c33-ab92-66052d75b663"),
                        Ad = "Öğretmen"
                    },
                    new GrupDTO()
                    {
                        Id=1,
                        Guid = new Guid("e9cb7e35-197d-4274-bb0a-61f7564d03dd"),
                        Ad = "İl Müdürü"
                    }
                }
            });
        }



        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            string output = JsonConvert.SerializeObject(entities[0]);

            return new string[] { output };
        }


       
        // POST api/values
        [HttpPost]
        //HangiAlanlarGonderildiAnlasilanDurum
        public ActionResult Post([FromBody]PersonelDTO personelDto)
        {

            if (personelDto == null || personelDto.Guid == Guid.Empty)
                throw new Exception("Hiç bir veri göndermediniz!");

            try
            {
                // git DB den verileri çek;
                var entity = entities.FirstOrDefault(x => x.Guid == personelDto.Guid);
                if (entity == null)
                    throw new Exception("Bu guide ait bir kayıt bulunamadı");

                entity.Ad = personelDto.Ad ?? entity.Ad;
                entity.Soyad = personelDto.Soyad ?? entity.Soyad;
                entity.CinsiyetId = personelDto.CinsiyetId ?? entity.CinsiyetId;
                entity.UyrukId = personelDto.UyrukId ?? entity.UyrukId;

                // if (o.ContainsKey("Gruplar")) ////böyle bir alan json modelde varsa güncelleyelim.
                // {
                //     if (entity.Gruplar == null)
                //     {
                //         entity.Gruplar = new List<GrupDTO>(); //linq sorgusu patlamasın diye null ise bir değer verelim
                //     }
                //     foreach (var g in o["Gruplar"].Children())
                //     {
                //         guid = new Guid(g["Guid"].ToString()); // guid değerini alalım
                //         if (!entity.Gruplar.Any(x => x.Guid == guid))
                //         {
                //             entity.Gruplar.Add(new GrupDTO()
                //             {
                //                 Guid = guid,
                //                 Ad = (string)g["Ad"]
                //             });
                //         }
                //         else
                //         {
                //             // zaten varsa bir şey yapmaya gerek yok
                //         }

                //     }
                // }

                var dbguncelle = entity;
                //************************************************************
                // SON OLARAK entity VERİ TABANINA GÖNDER KAYDETSİN
                //************************************************************
                return Ok(entity);

            }
            catch (Exception e)
            {
                throw new Exception("Geçersiz guid gönderdiniz!");
            }

        }

    }
}
