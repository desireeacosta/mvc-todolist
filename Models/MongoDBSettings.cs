namespace modelos_webdev.Models
{
    public class MongoDBSettings
    {
        public string ConnectionString { get; set;} = null!;

        public string DatabaseName { get; set;} = null!;

        public string CardsCollectionName { get; set;} = null!;
    }
}