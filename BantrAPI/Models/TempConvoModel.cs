using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BantrAPI.Models
{
    [BsonIgnoreExtraElements]

    //! I have no idea if this is going to work the way I want it to
    //! I need to figure out how to create a different, but similar
    public class TempConversation
    {
        public TempConversation(
            Conversation convoInfo,
            List<User> members
        )
        {
            this._id = convoInfo._id;
            this.name = convoInfo.name;
            this.members = members;
            this.messages = convoInfo.messages;
            this.updated_at = convoInfo.updated_at;
            this.created_at = convoInfo.created_at;
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("name")]
        public string name { get; set; }

        [BsonElement("members")]
        public List<User> members { get; set; }

        [BsonElement("messages")]
        public List<object> messages { get; set; }

        [BsonElement("updated_at")]
        public DateTime updated_at { get; set; }

        [BsonElement("created_at")]
        public DateTime created_at = DateTime.Now;
    }
}
