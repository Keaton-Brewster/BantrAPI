using BantrAPI.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using static System.Array;

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

        public List<Conversation> Get() =>
            _conversations.Find(conversation => true).ToList();

        public List<Conversation> Get(string id)
        // This is not working. Definitely going to need to do a lot more research on how to set up
        // propery controllers for c# 
        {
            var filter = Builders<Conversation>.Filter.Exists(conversation => IndexOf(conversation.members, id));
            return _conversations.Find(filter).ToList();
        }
        // var filter = Builders<Conversation>.Filter.Eq("members", id);
        //  _conversations.Find(conversation => conversation.members.Exists<Conversation>(id)).ToList();


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