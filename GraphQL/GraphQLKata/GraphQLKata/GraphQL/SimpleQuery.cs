using GraphQL.Types;
using GraphQLKata.GraphQL.Types;
using GraphQLKata.Repositories;

namespace GraphQLKata.GraphQL
{
    public class SimpleQuery : ObjectGraphType
    {
        public SimpleQuery(PersonRepository personRepository)
        {
            Field<ListGraphType<PersonType>>(
                "people",
                resolve: context => personRepository.GetAll()
            );
        }
    }
}
