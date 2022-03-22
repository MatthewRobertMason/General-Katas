namespace GraphQLInventorySystem.Repositories
{
    using GraphQLInventorySystem.Data;
    using GraphQLInventorySystem.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public class ItemCountsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ItemCountsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ItemCounts> GetAll()
        {
            return _dbContext.ItemCounts;
        }

        public IEnumerable<ItemCounts> GetAll(int inventoryId)
        {
            return _dbContext.ItemCounts.Where(p => p.InventoryId == inventoryId);
        }

        public async Task<ILookup<int, ItemCounts>> GetForItemCounts(IEnumerable<int> inventoryIds)
        {
            List<ItemCounts> inventories = await _dbContext.ItemCounts.Where(p => inventoryIds.Contains(p.InventoryId)).ToListAsync();
            return inventories.ToLookup(p => p.InventoryId);
        }

        public async Task<ItemCounts> AddItemCounts(ItemCounts itemCounts)
        {
            _dbContext.ItemCounts.Add(itemCounts);
            await _dbContext.SaveChangesAsync();
            return itemCounts;
        }
    }
}
