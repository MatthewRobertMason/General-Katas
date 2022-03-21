using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Types;
using GraphQLKata.Data.Entities;
using GraphQLKata.GraphQL.Types;
using GraphQLKata.Repositories;
using System.Reactive.Subjects;
using System.Reactive.Linq;

namespace GraphQLKata.GraphQL
{
    public class PersonAddedService
    {
        private readonly ISubject<PersonAddedMessage> _messageStream = new ReplaySubject<PersonAddedMessage>(1);

        public PersonAddedMessage AddPersonAddedMessage(Person person)
        {
            PersonAddedMessage message = new PersonAddedMessage
            {
                Id = person.Id,
                Name = person.Name,
                Age = person.Age
            };

            _messageStream.OnNext(message);
            return message;
        }

        public IObservable<PersonAddedMessage> GetMessages()
        {
            return _messageStream.AsObservable();
        }
    }
}