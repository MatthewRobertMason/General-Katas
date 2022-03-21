using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Types;
using GraphQLInventorySystem.Data.Entities;
using GraphQLInventorySystem.GraphQL.Types;
using GraphQLInventorySystem.Repositories;
using GraphQLInventorySystem.GraphQL.Messaging;

namespace GraphQLInventorySystem.GraphQL
{
    public class InventorySubscription : ObjectGraphType
    {
        public InventorySubscription(
            UserAddedService userAddedService,
            InventoryAddedService inventoryAddedService,
            ItemAddedService itemAddedService,
            ItemCountsAddedService itemCountsAddedService)
        {
            Name = "Subscription";

            AddField(new EventStreamFieldType
            {
                Name = "userAdded",
                Type = typeof(UserAddedMessageType),
                Resolver = new FuncFieldResolver<UserAddedMessage>(c => c.Source as UserAddedMessage),
                Subscriber = new EventStreamResolver<UserAddedMessage>(c => userAddedService.GetMessages())
            });

            AddField(new EventStreamFieldType
            {
                Name = "inventoryAdded",
                Type = typeof(InventoryAddedMessageType),
                Resolver = new FuncFieldResolver<InventoryAddedMessage>(c => c.Source as InventoryAddedMessage),
                Subscriber = new EventStreamResolver<InventoryAddedMessage>(c => inventoryAddedService.GetMessages())
            });

            AddField(new EventStreamFieldType
            {
                Name = "itemAdded",
                Type = typeof(ItemAddedMessageType),
                Resolver = new FuncFieldResolver<ItemAddedMessage>(c => c.Source as ItemAddedMessage),
                Subscriber = new EventStreamResolver<ItemAddedMessage>(c => itemAddedService.GetMessages())
            });

            AddField(new EventStreamFieldType
            {
                Name = "itemCountAdded",
                Type = typeof(ItemCountsAddedMessageType),
                Resolver = new FuncFieldResolver<ItemCountsAddedMessage>(c => c.Source as ItemCountsAddedMessage),
                Subscriber = new EventStreamResolver<ItemCountsAddedMessage>(c => itemCountsAddedService.GetMessages())
            });
        }
    }
}
