using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDataCreator.Sample.Model;
using TestDataCreator.Sample.Repostories;

namespace TestDataCreator.Sample
{
    [TestClass]
    public abstract class RepositoryIntegrationTestBase<T, TDataCreator>
        where T : Entity, new()
        where TDataCreator : Sample.ToBeReworked.TestDataCreator
    {
        protected T createdEntity;
        private TDataCreator creator;
        protected DbContext dbContext;
        protected IRepository<T> repository;

        protected TDataCreator EntityCreator
        {
            get
            {
                return creator;
            }
        }

        protected virtual bool EnableDelete
        {
            get
            {
                return true;
            }
        }

        protected virtual DbContext DbContext
        {
            get
            {
                return new TestableContext();
            }
        }

        [TestInitialize]
        public void SetupEachTest()
        {
            dbContext = DbContext;
            repository = CreateRepository(dbContext);
            creator = CreateEntityCreator(dbContext);
        }

        protected abstract TDataCreator CreateEntityCreator(DbContext context);

        [TestCleanup]
        public void TearDownEachTest()
        {
            if (createdEntity != null)
            {
                if (EnableDelete)
                {
                    creator.DeleteCreatedEntities();
                }
                dbContext.SaveChanges();
                createdEntity = null;
            }
            dbContext.Dispose();
            repository = null;
        }

        [TestMethod]
        public void  InsertOrUpdate_NewObjectProvided_CreatesSuccessfull()
        {
            T entity = CreateEntity();
            InsertOrUpdate(entity);
            createdEntity = entity;
            Console.WriteLine(createdEntity.DumpToString());
            Assert.IsTrue(!createdEntity.IsNew);
        }

        protected virtual void InsertOrUpdate(T entity)
        {
            repository.InsertOrUpdate(entity);
            try
            {
                dbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                e.EntityValidationErrors.SelectMany(error => error.ValidationErrors).ToList().ForEach(
                    item => Console.WriteLine("{0} - {1}", item.PropertyName, item.ErrorMessage));
                throw;
            }
        }

        protected abstract T CreateEntity();

        protected abstract IRepository<T> CreateRepository(DbContext context);
    }
}