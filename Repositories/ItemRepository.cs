using MongoDB.Bson;
using MongoDB.Driver;
using TypeDevApp.Interfaces;
using TypeDevApp.Models;

namespace TypeDevApp.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly IMongoCollection<Item> _collection;

        public ItemRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Item>("items");
        }

        public async Task<IEnumerable<Item>> GetAllItems()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<Item> GetItemById(string id)
        {
            var objectId = new ObjectId(id);
            return await _collection.Find(item => item.Id == objectId).FirstOrDefaultAsync();
        }

        public async Task CreateItem(Item item)
        {
            await _collection.InsertOneAsync(item);
        }

        public async Task UpdateItem(string id, Item item)
        {
            var objectId = new ObjectId(id);
            await _collection.ReplaceOneAsync(i => i.Id == objectId, item);
        }

        public async Task DeleteItem(string id)
        {
            var objectId = new ObjectId(id);
            await _collection.DeleteOneAsync(item => item.Id == objectId);
        }
    }
}
