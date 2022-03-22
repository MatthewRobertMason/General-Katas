namespace GraphQLInventorySystem.Repositories
{
    using GraphQLInventorySystem.Data;
    using GraphQLInventorySystem.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public class InventoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public InventoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Inventory> GetAll()
        {
            return _dbContext.Inventories;
        }

        public IEnumerable<Inventory> GetUserInventory(int userId)
        {
            return _dbContext.Inventories.Where(p => p.UserId == userId);
        }

        public async Task<ILookup<int, Inventory>> GetForInventories(IEnumerable<int> userIds)
        {
            List<Inventory> inventories = await _dbContext.Inventories.Where(p => userIds.Contains(p.Id)).ToListAsync();
            return inventories.ToLookup(p => p.UserId);
        }

        public async Task<Inventory> AddInventory(Inventory inventory)
        {
            _dbContext.Inventories.Add(inventory);
            await _dbContext.SaveChangesAsync();
            return inventory;
        }
    }
}
