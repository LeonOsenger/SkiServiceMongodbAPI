using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SkiServiceMongodbAPI.Models
{
    public class Dienstleistungen
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Dienstleistung { get; set; }

        public string Prioritaet { get; set; }

        public string Email { get; set; }

        public string Telefon { get; set; }

        public string Status { get; set; }

        public string Erstell_Datum { get; set; }

        public string Abhol_Datum { get; set; }
    }
}
