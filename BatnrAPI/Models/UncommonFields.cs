using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BantrAPI.Models.UncommonFields
{
    [BsonIgnoreExtraElements]
    public class Messages
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string sender_id { get; set; }

        [BsonElement("content")]
        public string Content { get; set; }

        [BsonElement("senderName")]
        public string SenderName { get; set; }
    }

    public class Members
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string member_id { get; set; }
    }
}