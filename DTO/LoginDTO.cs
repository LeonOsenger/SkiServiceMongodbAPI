using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SkiServiceMongodbAPI.DTO
{
    public class LoginDTO
    {
        [JsonPropertyName("Benutzer_Name")]
        public string BenutzerName { get; set; }

        [JsonPropertyName("Benutzer_Passwort")]
        public string BenutzerPasswort { get; set; }
    }
}
