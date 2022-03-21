using GraphQL.Types;
using GraphQLInventorySystem.Data.Entities;

namespace GraphQLInventorySystem.GraphQL.Types
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Field(t => t.Id);
            Field(t => t.Name);
        }
    }

    public class InventoryType : ObjectGraphType<Inventory>
    {
        public InventoryType()
        {
            Field(t => t.Id);
            Field(t => t.UserId);
            Field(t => t.Name);
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
        public ItemCountsType()
        {
            Field(t => t.ItemId);
            Field(t => t.InventoryId);
            Field(t => t.Count, nullable: true);
        }
    }
}
