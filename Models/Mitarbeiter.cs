using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SkiServiceMongodbAPI.Models
{
    public class Mitarbeiter
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; } = null!;

        public string Vorname { get; set; } = null!;

        public string Passwort { get; set; } = null!;
    }
}
