using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BantrAPI.Models.Subfields
{
    [BsonIgnoreExtraElements]
    public class Message
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("sender_id")]
        public string sender_id { get; set; }

        [BsonElement("senderName")]
        public string SenderName { get; set; }

        [BsonElement("content")]
        public string Content { get; set; }
    }
}
