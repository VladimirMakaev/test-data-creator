using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDataCreator.Sample.Model;
using TestDataCreator.Sample.Repostories;

namespace TestDataCreator.Sample.Tests
{
    [TestClass]
    class BlogRepositoryTest : RepositoryIntegrationTest<Blog>
    {
        protected override Blog CreateEntity()
        {
            return EntityCreator.CreateBlog();
        }

        protected override IRepository<Blog> CreateRepository(DbContext context)
        {
            return new BlogRepository(dbContext);
        }
    }
}