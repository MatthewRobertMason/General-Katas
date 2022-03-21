using GraphQL;
using GraphQL.Types;
using GraphQLInventorySystem.Data.Entities;
using GraphQLInventorySystem.GraphQL.Types;
using GraphQLInventorySystem.Repositories;
using GraphQLInventorySystem.GraphQL.Messaging;

namespace GraphQLInventorySystem.GraphQL
{
    public class InventoryMutation : ObjectGraphType
    {
        public InventoryMutation(
            UserRepository userRepository,
            UserAddedService userAddedService,
            InventoryRepository inventoryRepository,
            InventoryAddedService inventoryAddedService,
            ItemRepository itemRepository,
            ItemAddedService itemAddedService,
            ItemCountsRepository itemCountsRepository,
            ItemCountsAddedService itemCountsAddedService)
        {
            FieldAsync<UserType>(
                "addUser",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }),
                resolve: async context =>
                {
                    User user = context.GetArgument<User>("user");
                    await userRepository.AddUser(user);
                    userAddedService.AddUserAddedMessage(user);
                    return user;
                });

            FieldAsync<InventoryType>(
                "addInventory",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<InventoryInputType>> { Name = "inventory" }),
                resolve: async context =>
                {
                    Inventory inventory = context.GetArgument<Inventory>("inventory");
                    await inventoryRepository.AddInventory(inventory);
                    inventoryAddedService.AddInventoryAddedMessage(inventory);
                    return inventory;
                });

            FieldAsync<ItemType>(
                "addItem",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ItemInputType>> { Name = "item" }),
                resolve: async context =>
                {
                    Item item = context.GetArgument<Item>("item");
                    await itemRepository.AddItem(item);
                    itemAddedService.AddItemAddedMessage(item);
                    return item;
                });

            FieldAsync<ItemCountsType>(
                "addItemCounts",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ItemCountsInputType>> { Name = "itemCounts" }),
                resolve: async context =>
                {
                    ItemCounts itemCounts = context.GetArgument<ItemCounts>("itemCounts");
                    await itemCountsRepository.AddItemCounts(itemCounts);
                    itemCountsAddedService.AddItemCountAddedMessage(itemCounts);
                    return itemCounts;
                });
        }
    }
}