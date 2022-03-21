namespace GraphQLInventorySystem.Repositories
{
    using GraphQLInventorySystem.Data;
    using GraphQLInventorySystem.Data.Entities;

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

        public async Task<ItemCounts> AddItemCounts(ItemCounts itemCounts)
        {
            _dbContext.ItemCounts.Add(itemCounts);
            await _dbContext.SaveChangesAsync();
            return itemCounts;
        }
    }
}
