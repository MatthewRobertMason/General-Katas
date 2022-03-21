using System.ComponentModel.DataAnnotations;

namespace GraphQLKata.Data.Entities
{
    public class Person
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
        public int Age { get; set; }
        //public Person[] Friends { get; set; }
    }
}
