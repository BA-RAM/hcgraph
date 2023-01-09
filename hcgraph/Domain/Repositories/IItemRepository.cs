using HcGraph.Domain.Models;

namespace HcGraph.Domain.Repositories
{
    public interface IItemRepository
    {
        public Task<List<Item>> GetItems();

        public Task<Item?> GetItem(long rowID);
        
        public Task<Item?> GetItemByItemNumber(string itemNumber);
    }
}