using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SkiServiceMongodbAPI.Models
{
    public class Dienstleistungen
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Dienstleistung { get; set; } = null!;

        public string Prioritaet { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Telefon { get; set; } = null!;

        public string Status { get; set; } = null!;

        public string Erstell_Datum { get; set; } = null!;

        public string Abhol_Datum { get; set; } = null!;
    }
}
