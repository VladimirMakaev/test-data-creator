using System.Data.Entity;
using TestDataCreator.Sample.Model;

namespace TestDataCreator.Sample.Repostories
{
    public class BlogRepository : IRepository<Blog>
    {
        public BlogRepository(DbContext dbContext)
        {
            throw new System.NotImplementedException();
        }
        
        public void InsertOrUpdate(Blog entity)
        {
            throw new System.NotImplementedException();
        }
    }
}