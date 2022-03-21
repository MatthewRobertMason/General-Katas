namespace GraphQLInventorySystem.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Item
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

    }
}
