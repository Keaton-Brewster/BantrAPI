﻿using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BantrAPI.Models
{
    [BsonIgnoreExtraElements]

    public class Conversation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("name")]
        public string name { get; set; }

        [BsonElement("members")]
        public List<string> members { get; set; }

        [BsonElement("messages")]
        public List<object> messages { get; set; }

        [BsonElement("updated_at")]
        public DateTime updated_at { get; set; }

        [BsonElement("created_at")]
        public DateTime created_at = DateTime.Now;
    }
}