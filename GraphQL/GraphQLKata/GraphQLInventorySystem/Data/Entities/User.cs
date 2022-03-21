namespace GraphQLInventorySystem.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
