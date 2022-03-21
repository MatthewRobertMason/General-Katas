using GraphQL;
using GraphQL.Types;

namespace GraphQLInventorySystem.GraphQL
{
    public class InventorySchema : Schema
    {
        public InventorySchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetService<InventoryQuery>();
            Mutation = provider.GetService<InventoryMutation>();
            Subscription = provider.GetService<InventorySubscription>();
        }

    }
}
