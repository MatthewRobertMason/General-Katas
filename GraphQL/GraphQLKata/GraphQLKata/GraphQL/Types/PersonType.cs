using GraphQL.Types;
using GraphQLKata.Data.Entities;

namespace GraphQLKata.GraphQL.Types
{
    public class PersonType : ObjectGraphType<Person>
    {
        public PersonType()
        {
            Field(t => t.Id);
            Field(t => t.Name);
            Field(t => t.Age);
            //Field(t => t.Friends);
        }
    }
}
