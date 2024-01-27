using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Consume.Data
{
    public class DataModel : IDataModel<User>
    {
        public IEnumerable<User> GetData() => new List<User>
        {
            //new User { UserId = 1, FirstName = "Dilara", LastName = "PINAR", Email = "dilarapiinar@gmail.com" },
            new User { UserId = 2, FirstName = "Eda", LastName = "SAYAR", Email = "eda.sayar@bilgeadam.com" },
            //new User { UserId = 3, FirstName = "Mustafa", LastName = "KARADAŞ", Email = "mustafa.karadas@bilgeadam.com" },
            //new User { UserId = 4, FirstName = "Umut", LastName = "ÖNCEL", Email = "umut.oncel@bilgeadam.com" },
            //new User { UserId = 5, FirstName = "Eren", LastName = "KARTAL", Email = "eren.kartal@bilgeadam.com" },
            //new User { UserId = 6, FirstName = "Furkan Tolga", LastName = "KAHVECİ", Email = "tolga.kahveci@bilgeadam.com" },
            //new User { UserId = 7, FirstName = "Ali", LastName = "CALGAN", Email = "ali.calgan@bilgeadam.com" },
            //new User { UserId = 8, FirstName = "Anıl", LastName = "BAYRAKTAR", Email = "anil.bayraktar@bilgeadam.com" },
            //new User { UserId = 9, FirstName = "Muhammet", LastName = "DERELİ", Email = "muhammet.dereli@bilgeadam.com" },
            //new User { UserId = 10, FirstName = "Cem", LastName = "YAZICIOGLU", Email = "cem.yazicioglu@bilgeadam.com" },
            //new User { UserId = 11, FirstName = "Eren", LastName = "TASKIN", Email = "eren.taskin@bilgeadam.com" },
            //new User { UserId = 12, FirstName = "Enver", LastName = "YALCIN", Email = "enver.yalcin@bilgeadam.com" },
            //new User { UserId = 13, FirstName = "Dogukan", LastName = "ASLAN", Email = "dogukan.aslan@bilgeadam.com" },
            //new User { UserId = 14, FirstName = "Emrah", LastName = "SOZLU", Email = "emrah.sozlu@bilgeadam.com" },
            //new User { UserId = 15, FirstName = "Batuhan", LastName = "HAYBEK", Email = "batuhan.haybek@bilgeadam.com" },
            //new User { UserId = 16, FirstName = "Kiziltan Cihan", LastName = "ORAL", Email = "cihan.oral@bilgeadam.com" },
            //new User { UserId = 17, FirstName = "Sinan", LastName = "TASYAPAR", Email = "sinan.tasyapar@bilgeadam.com" },
            //new User { UserId = 18, FirstName = "Taylan", LastName = "SAYKAN", Email = "taylan.saykan@bilgeadam.com" },
            //new User { UserId = 19, FirstName = "Yasin", LastName = "GURBUZ", Email = "yasin.gurbuz@bilgeadam.com" },
            //new User { UserId = 20, FirstName = "Alper", LastName = "OGUL", Email = "alper.ogul@bilgeadam.com" },

        };
    }
}
