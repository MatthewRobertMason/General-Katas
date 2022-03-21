namespace GraphQLInventorySystem.Repositories
{
    using GraphQLInventorySystem.Data;
    using GraphQLInventorySystem.Data.Entities;

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

        public async Task<Inventory> AddInventory(Inventory inventory)
        {
            _dbContext.Inventories.Add(inventory);
            await _dbContext.SaveChangesAsync();
            return inventory;
        }
    }
}
