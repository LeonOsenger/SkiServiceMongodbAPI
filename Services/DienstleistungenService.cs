using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SkiServiceMongodbAPI.Models;

namespace SkiServiceMongodbAPI.Services
{
    public class DienstleistungenService
    {
        private readonly IMongoCollection<Dienstleistungen> _dienstleistungenCollection;

        public DienstleistungenService(IOptions<SkiServiceDatabaseSettings> skiServiceDatabaseSettings)
        {
            var mongoClient = new MongoClient(skiServiceDatabaseSettings.Value.ConnectionString);

            var mongoDB = mongoClient.GetDatabase(skiServiceDatabaseSettings.Value.DatabaseName);

            _dienstleistungenCollection = mongoDB.GetCollection<Dienstleistungen>(skiServiceDatabaseSettings.Value.DienstleistungenCollectionName);
        }
        
        public async Task<List<Dienstleistungen>> GetAsync() => 
            await _dienstleistungenCollection.Find(_ => true).ToListAsync();

        public async Task<Dienstleistungen?> GetAsync(string id) =>
        await _dienstleistungenCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Dienstleistungen newBook) =>
            await _dienstleistungenCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Dienstleistungen updatedDienstleistung) =>
            await _dienstleistungenCollection.ReplaceOneAsync(x => x.Id == id, updatedDienstleistung);

        public async Task RemoveAsync(string id) =>
            await _dienstleistungenCollection.DeleteOneAsync(x => x.Id == id);
    }
}
