using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BantrAPI.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }

        [BsonElement("date")]
        public BsonDateTime Date { get; set; }

        [BsonElement("picture")]
        public string Picture { get; set; }

        [BsonElement("contacts")]
        public object[] Contacts { get; set; }

    }
}
