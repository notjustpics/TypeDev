using TypeDevApp.Models;

namespace TypeDevApp.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllItems();
        Task<Item> GetItemById(string id);
        Task CreateItem(Item item);
        Task UpdateItem(string id, Item item);
        Task DeleteItem(string id);
    }
}
