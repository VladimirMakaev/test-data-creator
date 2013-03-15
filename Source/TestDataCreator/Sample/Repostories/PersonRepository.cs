using System.Data.Entity;
using TestDataCreator.Sample.Model;

namespace TestDataCreator.Sample.Repostories
{
    public class PersonRepository : IRepository<Person>
    {
        public PersonRepository(DbContext dbContext)
        {
            throw new System.NotImplementedException();
        }

        public void InsertOrUpdate(Person entity)
        {
            throw new System.NotImplementedException();
        }
    }
}