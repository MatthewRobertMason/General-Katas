using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQLInventorySystem.Data.Entities;
using GraphQLInventorySystem.Repositories;

namespace GraphQLInventorySystem.GraphQL.Types
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType(InventoryRepository inventoryRepository, IDataLoaderContextAccessor dataLoaderContextAccessor)
        {
            Field(t => t.Id);
            Field(t => t.Name);

            Field<ListGraphType<InventoryType>>(
                "inventories",
                resolve: context => 
                {
                    IDataLoader<int, IEnumerable<Inventory>> loader = dataLoaderContextAccessor.Context
                        .GetOrAddCollectionBatchLoader<int, Inventory>("GetInventoriesByUserId", inventoryRepository.GetForInventories);
                    
                    return loader.LoadAsync(context.Source.Id);
                });
        }
    }

    public class InventoryType : ObjectGraphType<Inventory>
    {
        public InventoryType(ItemCountsRepository itemCountsRepository, IDataLoaderContextAccessor dataLoaderContextAccessor)
        {
            Field(t => t.Id);
            Field(t => t.UserId);
            Field(t => t.Name);

            Field<ListGraphType<ItemCountsType>>(
                "itemCounts",
                resolve: context => 
                {
                    IDataLoader<int, IEnumerable<ItemCounts>> loader = dataLoaderContextAccessor.Context
                        .GetOrAddCollectionBatchLoader<int, ItemCounts>("GetItemCountsByInventoryId", itemCountsRepository.GetForItemCounts);

                    return loader.LoadAsync(context.Source.Id);
                });
        }
    }

    public class ItemType : ObjectGraphType<Item>
    {
        public ItemType()
        {
            Field(t => t.Id);
            Field(t => t.Name);
            Field(t => t.Description, nullable: true);
        }
    }

    public class ItemCountsType : ObjectGraphType<ItemCounts>
    {
        public ItemCountsType(ItemRepository itemRepository, IDataLoaderContextAccessor dataLoaderContextAccessor)
        {
            Field(t => t.ItemId);
            Field(t => t.InventoryId);
            Field(t => t.Count, nullable: true);

            Field<ItemType>(
                "itemData",
                resolve: context =>
                {
                    IDataLoader<int, Item> loader = dataLoaderContextAccessor.Context
                    .GetOrAddBatchLoader<int, Item>("GetItemsByItemId", itemRepository.GetForItems);

                    return loader.LoadAsync(context.Source.ItemId);
                });
        }
    }
}
