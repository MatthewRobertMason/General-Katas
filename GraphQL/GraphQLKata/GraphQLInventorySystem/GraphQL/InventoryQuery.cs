using GraphQL.Types;
using GraphQLInventorySystem.GraphQL.Types;
using GraphQLInventorySystem.Repositories;

namespace GraphQLInventorySystem.GraphQL
{
    public class InventoryQuery : ObjectGraphType
    {
        public InventoryQuery(
            UserRepository userRepository, 
            InventoryRepository inventoryRepository, 
            ItemRepository itemRepository, 
            ItemCountsRepository itemCountRepository)
        {
            Field<ListGraphType<UserType>>(
                "users",
                resolve: context => userRepository.GetAll()
            );

            Field<ListGraphType<InventoryType>>(
                "inventories",
                resolve: context => inventoryRepository.GetAll()
            );

            Field<ListGraphType<ItemType>>(
                "items",
                resolve: context => itemRepository.GetAll()
            );

            Field<ListGraphType<ItemCountsType>>(
                "itemCounts",
                resolve: context => itemCountRepository.GetAll()
            );
        }
    }
}
