﻿using System;
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
            this.GivenName = user.givenName;
            this.FamilyName = user.familyName;
            this.Email = user.email;
            this.imageUrl = user.imageUrl;
            this.GID = user.g_id;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("g_id")]
        public string GID { get; set; }

        [BsonElement("givenName")]
        public string GivenName { get; set; }

        [BsonElement("familyName")]
        public string FamilyName { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("phoneNum")]
        public string PhoneNum { get; set; }

        [BsonElement("createdAt")]
        public BsonDateTime Date { get; set; }

        [BsonElement("imageUrl")]
        public string imageUrl { get; set; }

        [BsonElement("contacts")]
        public object[] Contacts { get; set; }

    }
}
