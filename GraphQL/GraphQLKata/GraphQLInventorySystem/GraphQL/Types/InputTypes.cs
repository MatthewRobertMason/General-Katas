using GraphQL.Types;
using GraphQLInventorySystem.Data.Entities;

namespace GraphQLInventorySystem.GraphQL.Types
{
    public class UserInputType : InputObjectGraphType
    {
        public UserInputType()
        {
            Name = "userInput";
            Field<NonNullGraphType<StringGraphType>>(nameof(User.Name));
        }
    }

    public class InventoryInputType : InputObjectGraphType
    {
        public InventoryInputType()
        {
            Name = "inventoryInput";
            Field<NonNullGraphType<IntGraphType>>(nameof(Inventory.UserId));
            Field<NonNullGraphType<StringGraphType>>(nameof(Inventory.Name));
        }
    }

    public class ItemInputType : InputObjectGraphType
    {
        public ItemInputType()
        {
            Name = "itemInput";
            Field<NonNullGraphType<StringGraphType>>(nameof(Item.Name));
            Field<NonNullGraphType<StringGraphType>>(nameof(Item.Description));
        }
    }

    public class ItemCountsInputType : InputObjectGraphType
    {
        public ItemCountsInputType()
        {
            Name = "itemCountsInput";
            Field<NonNullGraphType<IntGraphType>>(nameof(ItemCounts.ItemId));
            Field<NonNullGraphType<IntGraphType>>(nameof(ItemCounts.InventoryId));
            Field<NonNullGraphType<IntGraphType>>(nameof(ItemCounts.Count));
        }
    }
}
