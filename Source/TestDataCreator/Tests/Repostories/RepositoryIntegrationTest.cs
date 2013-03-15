using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDataCreator.Sample.Model;

namespace TestDataCreator.Tests.Repostories
{
    [TestClass]
    public abstract class RepositoryIntegrationTest<T> :
        RepositoryIntegrationTestBase<T, Sample.ToBeReworked.TestDataCreator>
           where T : Entity, new()
    {
        protected override Sample.ToBeReworked.TestDataCreator CreateEntityCreator(DbContext context)
        {
            return new Sample.ToBeReworked.TestDataCreator(context);
        }
    }
}