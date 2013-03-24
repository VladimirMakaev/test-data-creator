using System;

namespace TestDataCreator.Nodes
{
    public class ObjectNodeKey
    {
        private readonly int number;
        private readonly Type type;

        public ObjectNodeKey(int number, Type type)
        {
            this.number = number;
            this.type = type;
        }

        protected bool Equals(ObjectNodeKey other)
        {
            return number == other.number && Equals(type, other.type);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ObjectNodeKey) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (number*397) ^ (type != null ? type.GetHashCode() : 0);
            }
        }
    }
}