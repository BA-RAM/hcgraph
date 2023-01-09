using HcGraph.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HcGraph.Domain.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly SampleDbContext _dbContext;

        public ItemRepository(SampleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Item>> GetItems() => _dbContext.Items.ToListAsync();

        public Task<Item?> GetItem(long rowID) => _dbContext.Items.Where(i => i.RowId == rowID).FirstOrDefaultAsync();

        public Task<Item?> GetItemByItemNumber(string itemNumber) => _dbContext.Items.Where(i => i.ItemNumber == itemNumber).FirstOrDefaultAsync();
    }
}