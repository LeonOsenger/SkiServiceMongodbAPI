using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SkiServiceMongodbAPI.Models
{
    public class Mitarbeiter
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Vorname { get; set; }

        public string Passwort { get; set; }
    }
}
