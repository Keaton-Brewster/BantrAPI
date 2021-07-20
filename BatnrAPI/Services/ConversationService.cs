using BantrAPI.Models;
using BantrAPI.Models.UncommonFields;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BantrAPI.Services
{
    public class ConversationService
    {
        private readonly IMongoCollection<Conversation> _conversations;

        public ConversationService(IBantrDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _conversations = database.GetCollection<Conversation>(settings.ConversationCollectionName);
        }

        public List<Conversation> GetAll() =>
            _conversations.Find(conversation => true).ToList();

        public bool CheckForMember(Conversation conversation, string id)
        {
            Convert.ChangeType(id, typeof(BsonObjectId));
            foreach (var member in conversation.members)
            {
                if (member == id)
                {
                    return true;
                }
            }
            return false;
        }
        public List<Conversation> Get(string id)
        // This is not working. Definitely going to need to do a lot more research on how to set up
        // propery controllers for c# 
        {
            // var filter = Builders<Conversation>.Filter.ElemMatch(x => x.members,
            //     Builders<Members>.Filter.AnyEq(x => x.member_id == id)
            //     );
            Convert.ChangeType(id, typeof(BsonObjectId));
            var filter = Builders<Conversation>.Filter.AnyIn(x => x.members, id);


            // var convos = _conversations.Find(conversation => CheckForMember(conversation, id)).ToList();
            var convos = _conversations.Find(filter).ToList();
            return convos;
            // return _conversations.Find(filter).ToList();

        }

        public Conversation Create(Conversation conversation)
        {
            _conversations.InsertOne(conversation);
            return conversation;
        }

        public void Update(string id, Conversation conversationIn) =>
            _conversations.ReplaceOne(conversation => conversation._id == id, conversationIn);

        public void Remove(Conversation conversationIn) =>
            _conversations.DeleteOne(conversation => conversation._id == conversationIn._id);

        public void Remove(string id) =>
            _conversations.DeleteOne(conversation => conversation._id == id);
    }
}