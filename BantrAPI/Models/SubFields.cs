using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BantrAPI.Models.ConversationSubfields
{
    [BsonIgnoreExtraElements]
    public class Message
    {
        [BsonElement("sender_id")]
        public ObjectId sender_id { get; set; }
        [BsonElement("senderName")]
        public string SenderName { get; set; }

        [BsonElement("content")]
        public string Content { get; set; }
    }
}
