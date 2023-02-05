namespace SkiServiceMongodbAPI.Models
{
    public class SkiServiceDatabaseSettings
    {
        public string DatabaseName { get; set; } = null!;

        public string ConnectionString { get; set; } = null!;

        public string DienstleistungenCollectionName { get; set; } = null!;

        public string MitarbeiterCollectionName { get; set; } = null!;
    }
}
