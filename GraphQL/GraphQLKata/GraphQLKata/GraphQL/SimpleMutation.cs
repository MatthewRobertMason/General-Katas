using GraphQL;
using GraphQL.Types;
using GraphQLKata.Data.Entities;
using GraphQLKata.GraphQL.Types;
using GraphQLKata.Repositories;

namespace GraphQLKata.GraphQL
{
    public class SimpleMutation : ObjectGraphType
    {
        public SimpleMutation(PersonRepository personRepository, PersonAddedService personAddedService)
        {
            FieldAsync<PersonType>(
                "addPerson",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PersonInputType>> { Name = "person" }),
                resolve: async context =>
                {
                    Person person = context.GetArgument<Person>("person");
                    await personRepository.AddPerson(person);
                    personAddedService.AddPersonAddedMessage(person);
                    return person;
                });
        }
    }
}