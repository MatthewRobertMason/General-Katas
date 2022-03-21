using GraphQL.Types;

namespace GraphQLKata.GraphQL
{
    public class PersonAddedMessageType : ObjectGraphType<PersonAddedMessage>
    {
        public PersonAddedMessageType()
        { 
            Field(t => t.Id);
            Field(t => t.Name);
            Field(t => t.Age);
        }
    }
}