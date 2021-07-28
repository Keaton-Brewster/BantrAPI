using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using BantrAPI.Types;

namespace BantrAPI.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        public User(TUser user)
        {
            this.givenName = user.givenName;
            this.familyName = user.familyName;
            this.email = user.email;
            this.imageUrl = user.imageUrl;
            this.g_id = user.g_id;
            this.phoneNum = user.phoneNum;
            this.createdAt = DateTime.Now;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("g_id")]
        public string g_id { get; set; }

        [BsonElement("givenName")]
        public string givenName { get; set; }

        [BsonElement("familyName")]
        public string familyName { get; set; }

        [BsonElement("email")]
        public string email { get; set; }

        [BsonElement("phoneNum")]
        public string phoneNum { get; set; }

        [BsonElement("createdAt")]
        public DateTime createdAt { get; set; }

        [BsonElement("imageUrl")]
        public string imageUrl { get; set; }

        [BsonElement("contacts")]
        public object[] contacts { get; set; }

    }
}
