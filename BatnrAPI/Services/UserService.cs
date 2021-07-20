using BantrAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

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

        public void Update(string id, User userIn) =>
            _users.ReplaceOne(user => user._id == id, userIn);

        public void Remove(User userIn) =>
            _users.DeleteOne(user => user._id == userIn._id);

        public void Remove(string id) =>
            _users.DeleteOne(user => user._id == id);
    }
}