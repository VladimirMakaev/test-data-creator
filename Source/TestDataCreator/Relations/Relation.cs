using System;

namespace TestDataCreator.Relations
{
    public class Relation
    {
        private Type from;
        private Type to;
        private RelationType type;

        public Relation(Type @from, Type to, RelationType type)
        {
            this.@from = @from;
            this.to = to;
            this.type = type;
        }

        public Type From
        {
            get
            {
                return @from;
            }
        }

        public Type To
        {
            get
            {
                return to;
            }
        }

        public RelationType Type
        {
            get
            {
                return type;
            }
        }
    }
}