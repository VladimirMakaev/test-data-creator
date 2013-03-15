using System;

namespace TestDataCreator.Sample.Model
{
    public class Blog : Entity
    {
        public int Id
        {
            get;
            set;
        }

        public BlogAuthor Author
        {
            get;
            set;
        }

        public int AuthorId
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public DateTime DateCreated
        {
            get;
            set;
        }

        public DateTime LastUpdated
        {
            get;
            set;
        }
    }
}