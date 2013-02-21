using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Reflection;
using TestDataCreator.Sample.Model;

namespace HSS.HousingHub.Data.Services.Tests.TestData
{
    public class TestDataCreator
    {
        private readonly DbContext dbContext;

        private readonly Dictionary<Type, object> identityMap = new Dictionary<Type, object>();


        public TestDataCreator(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool HasObjectOfType<T>()
        {
            return identityMap.ContainsKey(typeof (T));
        }

        public void Attach<T>(T entity)
        {
            Console.WriteLine("Attaching instance of {0}", typeof (T).Name);
            identityMap[typeof (T)] = entity;
        }

        protected T GetOrCreate<T>(Func<T> entityCreator)
        {
            if (identityMap.ContainsKey(typeof (T)))
            {
                return (T) identityMap[typeof (T)];
            }
            Console.WriteLine(string.Format("Creating instance of {0}", typeof (T).Name));
            T entity = entityCreator();
            identityMap.Add(typeof (T), entity);
            return entity;
        }

        public void DeleteCreatedEntities()
        {
            foreach (var entry in identityMap)
            {
                Console.WriteLine(string.Format("Removing instance of {0} from DbContext", entry.Key.Name));
                DbSet dbSet = dbContext.Set(entry.Key);
                dbSet.Remove(entry.Value);
            }
            dbContext.SaveChanges();
        }

        public T Create<T>()
        {
            string name = "Create" + typeof (T).Name;
            MethodInfo methodInfo = GetType().GetMethod(name);
            Contract.Assert(methodInfo != null, "Implement " + methodInfo + " method in TestDataCreator");
            return (T) methodInfo.Invoke(this, null);
        }


        public Tag CreateTag()
        {
            return GetOrCreate(() => new Tag {Name = "node.js"});
        }

        public Person CreatePerson()
        {
            return GetOrCreate(() => new Person {Email = "test@user.com", Nickname = "testUser"});
        }

        public BlogAuthor CreateBlogAuthor()
        {
            return
                GetOrCreate(
                    () =>
                    new BlogAuthor {Email = "test@user.com", FirstName = "John", LastName = "Doe", Nickname = "jdoe"});
        }

        public Comment CreateComment()
        {
            return GetOrCreate(() => new Comment {Author = CreatePerson(), CommentText = "This is the best post"});
        }

        public Post CreatePost()
        {
            return
                GetOrCreate(
                    () =>
                    new Post
                        {
                            Comments = new List<Comment> {CreateComment()},
                            DateCreated = DateTime.Now,
                            RelativeUrl = "/the-very-best-post",
                            Tags = new Collection<Tag> {CreateTag()},
                            Title = "The Very Best Post"
                        });
        }
    }
}