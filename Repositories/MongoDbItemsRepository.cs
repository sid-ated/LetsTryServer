using LetsTry.Dtos;
using LetsTry.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsTry.Repositories
{
    public class MongoDbItemsRepository : IUsersRepository
    {
        private const string databaseName = "sample_temp";

        private const string collectionName = "temp0";
             
        private readonly IMongoCollection<User> usersCollection;

        private readonly FilterDefinitionBuilder<User> filterBuilder = Builders<User>.Filter;

        public MongoDbItemsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            usersCollection = database.GetCollection<User>(collectionName);
        }

        public async Task CreateUserAsync(CreatedUserDto UserDto)
        {

            User user = new()
            {
                Id = Guid.NewGuid(),
                FirstName = UserDto.FirstName,
                LastName = UserDto.LastName,
                DateOfBirth = UserDto.DateOfBirth,
                PlaceOfBirth = UserDto.PlaceOfBirth,
                MobileNumber = UserDto.MobileNumber,
                EmailId = UserDto.EmailId
            };
            await usersCollection.InsertOneAsync(user);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var filter = filterBuilder.Eq(user => user.Id, id);
            await usersCollection.DeleteOneAsync(filter);
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            var filter = filterBuilder.Eq(user => user.Id, id);
            return await usersCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await usersCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            var filter = filterBuilder.Eq(existingUser => existingUser.Id, user.Id);
            await usersCollection.ReplaceOneAsync(filter, user);
        }

        public async Task<Boolean> KycVerificationAsync(CreatedUserDto userDto)
        {
                await Task.Delay(1000);
                return true;
        }

        public async Task<IEnumerable<User>> GetUsersByNameAsync(string firstName, string lastName)
        {
            return await usersCollection.Find(user => user.FirstName == firstName 
                                    && user.LastName == lastName).ToListAsync();
        }

        public async Task<User> GetExactUserAsync(CreatedUserDto user)
        {
            return await usersCollection.Find(u => u.FirstName == user.FirstName
            && u.LastName == user.LastName && u.DateOfBirth == user.DateOfBirth && u.EmailId == user.EmailId
            && u.MobileNumber == user.MobileNumber).SingleOrDefaultAsync();
        }
    }
}
