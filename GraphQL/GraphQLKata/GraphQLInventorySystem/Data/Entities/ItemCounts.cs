namespace GraphQLInventorySystem.Data.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ItemCounts
    {
        [Required]
        public int ItemId { get; set; }

        [Required]
        public int InventoryId { get; set; }

        public int? Count { get; set; }

        [ForeignKey(nameof(ItemId))]
        public Item ItemInfo { get; set; }

        [ForeignKey(nameof(InventoryId))]
        public Inventory ContainingInventory { get; set; }
    }
}
