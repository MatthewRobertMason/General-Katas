namespace GraphQLInventorySystem.Repositories
{
    using GraphQLInventorySystem.Data;
    using GraphQLInventorySystem.Data.Entities;

    public class ItemRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Item> GetAll()
        {
            return _dbContext.Items;
        }

        public async Task<Item> AddItem(Item item)
        {
            _dbContext.Items.Add(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }
    }
}
