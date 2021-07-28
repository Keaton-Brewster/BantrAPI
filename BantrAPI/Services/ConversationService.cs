using BantrAPI.Models;
using BantrAPI.Types;
using BantrAPI.Models.Subfields;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

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


        public ConvoInfo GetConversationInformation(string convoId)
        {
            Conversation thisConversation = _conversations.Find(conversation => conversation._id == convoId).First();
            thisConversation.messages = null;
            List<string> ids = thisConversation.members;
            List<User> theseUsers = _users.Find(user => ids.Contains(user._id)).ToList();
            // Had to create a custom class to return the modified conversation information
            ConvoInfo resultConvo = new ConvoInfo(thisConversation, theseUsers);
            return resultConvo;
        }

        public Conversation Create(Conversation conversation)
        {
            _conversations.InsertOne(conversation);
            return conversation;
        }

        public Conversation PutNewMessage(TNewMessage newMessageObject)
        {
            Message message = newMessageObject.message;
            string convo_id = newMessageObject.conversation_id;

            var filter = Builders<Conversation>
             .Filter.Eq(convo => convo._id, convo_id);

            var update = Builders<Conversation>.Update
                    .Push<Message>(convo => convo.messages, message);

            _conversations.FindOneAndUpdate(filter, update);
            Conversation result = _conversations.Find(convo => convo._id == convo_id).FirstOrDefault();
            return result;
        }

        public void Update(string id, Conversation conversationIn) =>
            _conversations.ReplaceOne(conversation => conversation._id == id, conversationIn);

        public void Remove(Conversation conversationIn) =>
            _conversations.DeleteOne(conversation => conversation._id == conversationIn._id);

        public void Remove(string id) =>
            _conversations.DeleteOne(conversation => conversation._id == id);
    }
}