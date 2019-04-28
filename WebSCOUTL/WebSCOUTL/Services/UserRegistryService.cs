using MongoDB.Driver;
using WebSCOUTL.Enums;
using WebSCOUTL.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebSCOUTL.IServices;
using Microsoft.Extensions.Configuration;

namespace WebSCOUTL.Services
{
    public class UserRegistryService : IUserRegistryService
    {
        private IMongoCollection<UserRegistry> Collection;
        private UserRegistry Pagging;

        public UserRegistryService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("Host"));
            var database = client.GetDatabase("scoutl");
            Collection = database.GetCollection<UserRegistry>("user_registry");
        }

        public async Task<List<UserRegistry>> GetUserRegistries(int pageSize, EPaginationKey? paginationKey)
        {
            List<UserRegistry> result = new List<UserRegistry>();

            result = await Collection.Find(i => true)
                       .Limit(pageSize)
                       .ToListAsync();

            Pagging = result.Last();

            switch (paginationKey)
            {
                case EPaginationKey.NEXT_PAGE:
                    var filterNext = Builders<UserRegistry>
                        .Filter.Gt(i => i.Counter, Pagging.Counter);

                    result = await Collection.Find(filterNext)
                        .Limit(pageSize)
                        .ToListAsync();

                    Pagging = result.First();
                    break;
                case EPaginationKey.PREVIOUS_PAGE:
                    var filterPrev = Builders<UserRegistry>
                        .Filter.Lt(i => i.Counter, Pagging.Counter);

                    result = await Collection.Find(filterPrev)
                        .Limit(pageSize)
                        .ToListAsync();
                    break;
            }

            return result;
        }

        public async Task<UserRegistry> GetUserRegistryById(string id)
        {
            return await Collection.Find(user => user.Id == id).FirstOrDefaultAsync();
        }

        public async Task<UserRegistry> CreateUserRegistry(UserRegistry registry)
        {
            await Collection.InsertOneAsync(registry);
            return registry;
        }

        public async Task UpdateUserRegistry(string id, UserRegistry registry)
        {
            ReplaceOneResult replace = await Collection.ReplaceOneAsync(user => user.Id == id, registry);

            //return replace.ModifiedCount > 0;
        }

        public async Task DeleteUserRegistry(string id)
        {
            DeleteResult delete = await Collection.DeleteOneAsync(user => user.Id == id);
            //return delete.DeletedCount > 0;
        }
    }
}
