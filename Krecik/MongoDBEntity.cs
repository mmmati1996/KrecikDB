using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using MongoDB.Driver.Linq;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Krecik
{
    public class MongoDBEntity
    {
        public class Users
        {
            public ObjectId Id { get; }
            public string login { get; set; }
            public string password { get; set; }
            public int permission { get; set; } //1-admin, 0-user
            public string czaszalogowania { get; set; }
            public string czaswylogowania { get; set; }
            public UserInfo dane { get; set; }
        }

        public class UserInfo
        {
            public string Imie { get; set; }
            public string Nazwisko { get; set; }
            public string Adres { get; set; }
            public string AdresEmail { get; set; }
            public string NumerTelefonu { get; set; }
        }
    }
}
