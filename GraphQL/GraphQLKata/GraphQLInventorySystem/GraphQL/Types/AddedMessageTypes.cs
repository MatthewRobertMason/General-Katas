using GraphQL.Types;
using GraphQLInventorySystem.GraphQL.Messaging;

namespace GraphQLInventorySystem.GraphQL.Types
{
    public class UserAddedMessageType : ObjectGraphType<UserAddedMessage>
    {
        public UserAddedMessageType()
        {
            Field(t => t.Id);
            Field(t => t.Name);
        }
    }

    public class InventoryAddedMessageType : ObjectGraphType<InventoryAddedMessage>
    {
        public InventoryAddedMessageType()
        {
            Field(t => t.Id);
            Field(t => t.UserId);
            Field(t => t.Name);
        }
    }

    public class ItemAddedMessageType : ObjectGraphType<ItemAddedMessage>
    {
        public ItemAddedMessageType()
        {
            Field(t => t.Id);
            Field(t => t.Name);
            Field(t => t.Description, nullable:true);
        }
    }

    public class ItemCountsAddedMessageType : ObjectGraphType<ItemCountsAddedMessage>
    {
        public ItemCountsAddedMessageType()
        {
            Field(t => t.ItemId);
            Field(t => t.InventoryId);
            Field(t => t.Count, nullable:true);
        }
    }
}
