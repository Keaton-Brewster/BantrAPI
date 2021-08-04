namespace BantrAPI.Models
{
    public class BantrDatabaseSettings : IBantrDatabaseSettings
    {
        public string UserCollectionName { get; set; }
        public string ConversationCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IBantrDatabaseSettings
    {
        string UserCollectionName { get; set; }
        string ConversationCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}