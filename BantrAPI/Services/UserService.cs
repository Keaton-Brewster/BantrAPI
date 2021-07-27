﻿using BantrAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using MongoDB.Bson;

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
            // _users.Indexes.CreateOne(
            //     new CreateIndexModel<User>(Builders<User>.IndexKeys.Descending(model => model.Email),
            //     new CreateIndexOptions { Unique = true }));
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

        public User Login(string key) =>
            _users.Find(user => user.Key == key).FirstOrDefault();

        public void Update(string id, User userIn) =>
            _users.ReplaceOne(user => user._id == id, userIn);

        public void Remove(User userIn) =>
            _users.DeleteOne(user => user._id == userIn._id);

        public void Remove(string id) =>
            _users.DeleteOne(user => user._id == id);
    }
}