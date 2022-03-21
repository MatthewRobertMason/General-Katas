using GraphQL.Types;

namespace GraphQLInventorySystem.GraphQL.Messaging
{
    public class UserAddedMessage
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class InventoryAddedMessage
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
    }

    public class ItemAddedMessage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }

    public class ItemCountsAddedMessage
    {
        public int ItemId { get; set; }
        public int InventoryId { get; set; }
        public int? Count { get; set; }
    }
}
