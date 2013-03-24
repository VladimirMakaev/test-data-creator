using System;
using System.Collections.Generic;
using TestDataCreator.Nodes;

namespace TestDataCreator.Identities
{
    public class IdentityMap
    {
        private readonly Dictionary<ObjectNodeKey, Object> map = new Dictionary<ObjectNodeKey, object>();

        public bool HasObject(ObjectNodeKey key)
        {
            return map.ContainsKey(key);
        }

        public object GetObject(ObjectNodeKey key)
        {
            return map[key];
        }

        public object GetOrCreate(ObjectNodeKey key, Func<Object> creator)
        {
            if (map.ContainsKey(key))
            {
                return map[key];
            }
            object value = creator();
            map.Add(key, value);
            return value;
        }
    }
}