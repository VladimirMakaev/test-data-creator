using System;
using System.Collections.Generic;

namespace TestDataCreator.Sample.Model
{
    public class Post
    {
        public string Title
        {
            get;
            set;
        }

        public string RelativeUrl
        {
            get;
            set;
        }

        public DateTime DateCreated
        {
            get;
            set;
        }

        public ICollection<Tag> Tags
        {
            get;
            set;
        }

        public ICollection<Comment> Comments
        {
            get;
            set;
        }
    }
}