using System;
using BantrAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace BantrAPI.Services
{
    public class ConversationService
    {
        private readonly IMongoCollection<Conversation> _conversations;
        private readonly IMongoCollection<User> _users;
        private IMongoDatabase DB;

        public ConversationService(IBantrDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _conversations = database.GetCollection<Conversation>(settings.ConversationCollectionName);
            _users = database.GetCollection<User>(settings.UserCollectionName);
        }

        public List<Conversation> Get() =>
            _conversations.Find(conversation => true).ToList();

        public List<Conversation> Get(string id) =>
            _conversations.Find(x => x.members.Contains(id)).ToList();


        public TempConversation GetConversationInformation(string convoId)
        {
            Conversation thisConversation = _conversations.Find(conversation => conversation._id == convoId).First();
            List<string> ids = thisConversation.members;
            List<User> theseUsers = _users.Find(user => ids.Contains(user._id)).ToList();
            theseUsers.ForEach(user => user.Password = null);

            TempConversation resultConvo = new TempConversation(thisConversation, theseUsers);
            return resultConvo;

            /* Get Ids of Members in the conversation, call the db and get their information
                Then programatically fill in their:
                     ID
                     Email
                     Phone
                     Picture
                     Name
                Then reconstruct the Conversation<> and send it back in the response
                
                I am probably going to have to create a new static type
                for the conversation so that I can send it back with the 
                new types of member information
                (Converting from <string> to <object>)


                UPDATE
                At the point now where I have the conversation information, 
                And the information of the users in the conversation
                Now I have to figure out how to create a new conversation with  
                with some sort of constructor I am assuming.
            */
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