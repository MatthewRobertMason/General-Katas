using GraphQLKata.Data;
using GraphQLKata.Data.Entities;

namespace GraphQLKata.Repositories
{
    public class PersonRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PersonRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Person> GetAll()
        {
            return _dbContext.People;
        }

        public async Task<Person> AddPerson(Person person)
        {
            _dbContext.People.Add(person);
            await _dbContext.SaveChangesAsync();
            return person;
        }
    }
}
