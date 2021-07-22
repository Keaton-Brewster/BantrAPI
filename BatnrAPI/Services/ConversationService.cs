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
        private IMongoDatabase DB;

        public ConversationService(IBantrDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _conversations = database.GetCollection<Conversation>(settings.ConversationCollectionName);
        }

        private void dbAccess(IBantrDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            DB = client.GetDatabase(settings.DatabaseName);
        }

        public List<Conversation> GetAll() =>
            _conversations.Find(conversation => true).ToList();

        public ActionResult<List<Conversation>> Get(string id) =>
            _conversations.Find(x => x.members.Contains(id)).ToList();

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