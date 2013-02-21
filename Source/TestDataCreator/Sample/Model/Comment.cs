namespace TestDataCreator.Sample.Model
{
    public class Comment
    {
        public Person Author
        {
            get;
            set;
        }

        public int AuthorId
        {
            get;
            set;
        }

        public string CommentText
        {
            get;
            set;
        }
    }
}