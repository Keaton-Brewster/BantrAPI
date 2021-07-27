using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using BantrAPI.Models.Subfields;

namespace BantrAPI.Types
{
    public class TNewMessage
    {
        public Message message { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string conversation_id { get; set; }
    }
}