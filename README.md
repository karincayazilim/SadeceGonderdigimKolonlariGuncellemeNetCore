# SadeceGonderdigimKolonlariGuncellemeNetCore
.net core Web Api de client tarafından sadece gönderilen alanların verilerinin güncellenmesi uygulaması

Sistemde Bulunan kayıt:(güncelleme işlemi Guid değerine göre olmaktadır.
["{
"Guid":"813a19b9-6ffd-4637-b592-4b119a0d67b8",
"Ad":"Ad1",
"Soyad":"Soyad2",
"CinsiyetId":1,
"UyrukId":2,
"Gruplar":[
{"Guid":"fbabfe74-3ade-4c33-ab92-66052d75b663","Ad":"Öğretmen"},
{"Guid":"e9cb7e35-197d-4274-bb0a-61f7564d03dd","Ad":"İl Müdürü"}
]
}"]

__________________________________________________________________
Postmanda güncelleme için veri gönderme işlemi:
POST:  http://localhost:57947/api/values

Raw: JSON(application/json)
Body: "{\"Guid\":\"813a19b9-6ffd-4637-b592-4b119a0d67b8\",\"Ad\":\"Ad1111\",\"Soyad\":\"Soyad2222\",\"CinsiyetId\":111,\"UyrukId\":2222,\"Gruplar\":[{\"Guid\":\"fbabfe74-3ade-4c33-ab92-66052d75b665\",\"Ad\":\"Öğretmen\"},{\"Guid\":\"e9cb7e35-197d-4274-bb0a-61f7564d03de\",\"Ad\":\"İl Müdürü\"}]}"


Sonuç: Güncellenen veriyi göstermektedir.
{
    "guid": "813a19b9-6ffd-4637-b592-4b119a0d67b8",
    "ad": "Ad1111",
    "soyad": "Soyad2222",
    "cinsiyetId": 111,
    "uyrukId": 2222,
    "gruplar": [
        {
            "guid": "fbabfe74-3ade-4c33-ab92-66052d75b663",
            "ad": "Öğretmen"
        },
        {
            "guid": "e9cb7e35-197d-4274-bb0a-61f7564d03dd",
            "ad": "İl Müdürü"
        },
        {
            "guid": "fbabfe74-3ade-4c33-ab92-66052d75b665",
            "ad": "Öğretmen"
        },
        {
            "guid": "e9cb7e35-197d-4274-bb0a-61f7564d03de",
            "ad": "İl Müdürü"
        }
    ]
}

_______________________________________________________________

Şimdi sadece Ad güncellemesi yapalım
Body: "{\"Guid\":\"813a19b9-6ffd-4637-b592-4b119a0d67b8\",\"Ad\":\"SADECE AD DEĞİŞTİR\"}"


Sonuç: JSON
{
    "guid": "813a19b9-6ffd-4637-b592-4b119a0d67b8",
    "ad": "SADECE AD DEĞİŞTİR",
    "soyad": "Soyad2",
    "cinsiyetId": 1,
    "uyrukId": 2,
    "gruplar": [
        {
            "guid": "fbabfe74-3ade-4c33-ab92-66052d75b663",
            "ad": "Öğretmen"
        },
        {
            "guid": "e9cb7e35-197d-4274-bb0a-61f7564d03dd",
            "ad": "İl Müdürü"
        }
    ]
}


