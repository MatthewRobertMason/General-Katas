using GraphQL;
using GraphQL.Types;

namespace GraphQLKata.GraphQL
{
    public class SimpleSchema : Schema
    {
        public SimpleSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetService<SimpleQuery>();
            Mutation = provider.GetService<SimpleMutation>();
            Subscription = provider.GetService<SimpleSubscription>();
        }

    }
}
