using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Types;
using GraphQLInventorySystem.Data.Entities;
using GraphQLInventorySystem.GraphQL.Types;
using GraphQLInventorySystem.Repositories;
using System.Reactive.Subjects;
using System.Reactive.Linq;

namespace GraphQLInventorySystem.GraphQL.Messaging
{
    public class UserAddedService
    {
        private readonly ISubject<UserAddedMessage> _messageStream = new ReplaySubject<UserAddedMessage>(1);

        public UserAddedMessage AddUserAddedMessage(User user)
        {
            UserAddedMessage message = new UserAddedMessage
            {
                Id = user.Id,
                Name = user.Name
            };

            _messageStream.OnNext(message);
            return message;
        }

        public IObservable<UserAddedMessage> GetMessages()
        {
            return _messageStream.AsObservable();
        }
    }

    public class InventoryAddedService
    {
        private readonly ISubject<InventoryAddedMessage> _messageStream = new ReplaySubject<InventoryAddedMessage>(1);

        public InventoryAddedMessage AddInventoryAddedMessage(Inventory inventory)
        {
            InventoryAddedMessage message = new InventoryAddedMessage
            {
                Id = inventory.Id,
                UserId = inventory.UserId,
                Name = inventory.Name
            };

            _messageStream.OnNext(message);
            return message;
        }

        public IObservable<InventoryAddedMessage> GetMessages()
        {
            return _messageStream.AsObservable();
        }
    }

    public class ItemAddedService
    {
        private readonly ISubject<ItemAddedMessage> _messageStream = new ReplaySubject<ItemAddedMessage>(1);

        public ItemAddedMessage AddItemAddedMessage(Item item)
        {
            ItemAddedMessage message = new ItemAddedMessage
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description
            };

            _messageStream.OnNext(message);
            return message;
        }

        public IObservable<ItemAddedMessage> GetMessages()
        {
            return _messageStream.AsObservable();
        }
    }

    public class ItemCountsAddedService
    {
        private readonly ISubject<ItemCountsAddedMessage> _messageStream = new ReplaySubject<ItemCountsAddedMessage>(1);

        public ItemCountsAddedMessage AddItemCountAddedMessage(ItemCounts itemCount)
        {
            ItemCountsAddedMessage message = new ItemCountsAddedMessage
            {
                ItemId = itemCount.ItemId,
                InventoryId = itemCount.InventoryId,
                Count = itemCount.Count
            };

            _messageStream.OnNext(message);
            return message;
        }

        public IObservable<ItemCountsAddedMessage> GetMessages()
        {
            return _messageStream.AsObservable();
        }
    }
}
