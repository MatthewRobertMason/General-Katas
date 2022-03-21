using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Types;
using GraphQLKata.Data.Entities;
using GraphQLKata.GraphQL.Types;
using GraphQLKata.Repositories;

namespace GraphQLKata.GraphQL
{
    public class SimpleSubscription : ObjectGraphType
    {
        public SimpleSubscription(PersonAddedService personService)
        {
            Name = "Subscription";
            AddField(new EventStreamFieldType
            {
                Name = "personAdded",
                Type = typeof(PersonAddedMessageType),
                Resolver = new FuncFieldResolver<PersonAddedMessage>(c => c.Source as PersonAddedMessage ),
                Subscriber = new EventStreamResolver<PersonAddedMessage>(c => personService.GetMessages())
            });
        }
    }
}
