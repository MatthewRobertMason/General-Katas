namespace GraphQLInventorySystem.Repositories
{
    using GraphQLInventorySystem.Data;
    using GraphQLInventorySystem.Data.Entities;
    using Microsoft.EntityFrameworkCore;

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

        public Item GetItem(int itemId)
        {
            return _dbContext.Items.FirstOrDefault(p => p.Id == itemId);
        }

        public async Task<IDictionary<int, Item>> GetForItems(IEnumerable<int> itemIds)
        {
            List<Item> items = await _dbContext.Items.Where(p => itemIds.Contains(p.Id)).ToListAsync();
            return items.ToDictionary(p => p.Id);
        }

        public async Task<Item> AddItem(Item item)
        {
            _dbContext.Items.Add(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }
    }
}
