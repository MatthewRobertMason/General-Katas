using GraphQL.Types;

namespace GraphQLKata.GraphQL
{
    public class PersonAddedMessage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}