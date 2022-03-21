using GraphQL.Types;

namespace GraphQLKata.GraphQL.Types
{
    public class PersonInputType : InputObjectGraphType
    {
        public PersonInputType()
        {
            Name = "personInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<IntGraphType>>("age");
        }
    }
}
