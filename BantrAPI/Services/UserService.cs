using BantrAPI.Models;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Serializers;
using System.Collections.Generic;
using System.Linq;
using BantrAPI.Types;

namespace BantrAPI.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IBantrDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UserCollectionName);
            //? Was trying to figure out a way to keep user objects unique by email
            //? But that has turned into a struggle for some reason

            // var userBuilder = Builders<User>.IndexKeys;
            // var indexModel = new CreateIndexModel<User>(userBuilder.Ascending(x => x.email));
            // _users.Indexes
            //           .CreateOneAsync(indexModel);

            // _users.EnsureIndex(IndexKeys.Ascending(""), IndexOptions.SetUnique(true));
            // _users.Indexes.CreateOne(
            //     new CreateIndexModel<User>(Builders<User>.IndexKeys.Descending(model => model.Email),
        }

        public List<User> Get() =>
            _users.Find(user => true).ToList();

        public User Get(string id) =>
            _users.Find<User>(user => user._id == id).FirstOrDefault();

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public User Login(TKey key) =>
            _users.Find(user => user.email == key.y && user.g_id == key.z).FirstOrDefault();

        public void Update(string id, User userIn) =>
            _users.ReplaceOne(user => user._id == id, userIn);

        public void Remove(User userIn) =>
            _users.DeleteOne(user => user._id == userIn._id);

        public void Remove(string id) =>
            _users.DeleteOne(user => user._id == id);
    }
}