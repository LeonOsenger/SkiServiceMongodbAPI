using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using SkiServiceMongodbAPI.DTO;
using SkiServiceMongodbAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SkiServiceMongodbAPI.Services
{
    public class MitarbeiterLoginService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly IMongoCollection<Mitarbeiter> _mitarbeiterCollection;

        public MitarbeiterLoginService(IOptions<SkiServiceDatabaseSettings> skiServiceDatabaseSettings, IConfiguration config)
        {
            var mongoClient = new MongoClient(skiServiceDatabaseSettings.Value.ConnectionString);

            var mongoDB = mongoClient.GetDatabase(skiServiceDatabaseSettings.Value.DatabaseName);

            _mitarbeiterCollection = mongoDB.GetCollection<Mitarbeiter>(skiServiceDatabaseSettings.Value.MitarbeiterCollectionName);
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        }

        public string CreateToken(string username)
        {
            var claim = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, username)
            };

            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claim),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = cred
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }

        public bool CheckUser(string Vorname, string Passwort)
        {
            List<Mitarbeiter> User = _mitarbeiterCollection.Find(_ => true).ToList();
            LoginDTO login = new LoginDTO();

            foreach (var U in User)
            {
                if (Vorname == U.Vorname && Passwort == U.Passwort)
                {
                    login.BenutzerName = U.Vorname;
                    login.BenutzerPasswort = U.Passwort;
                    return true;
                }
            }
            return false;
        }
    }
}
