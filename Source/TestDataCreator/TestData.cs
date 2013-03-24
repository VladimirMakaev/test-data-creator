using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TestDataCreator.Identities;
using TestDataCreator.Nodes;
using TestDataCreator.Relations;

namespace TestDataCreator
{
    public class TestData
    {
        private readonly IdentityMap map = new IdentityMap();
        private IRelationshipResolver relationResolver;

        public IEnumerable<object> CreateMulti(Type objectType, int count)
        {
            return Enumerable.Range(1, count).Select(number => CreateOrdinal(objectType, number));
        }

        private object CreateOrdinal(Type objectType, int number)
        {
            var objectNodeKey = new ObjectNodeKey(number, objectType);

            if (map.HasObject(objectNodeKey))
            {
                return map.GetObject(objectNodeKey);
            }

            object single = map.GetOrCreate(objectNodeKey, () => Activator.CreateInstance(objectType));

            foreach (PropertyInfo propertyInfo in
                objectType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                          .Where(prop => !prop.PropertyType.IsPrimitive))
            {
                propertyInfo.SetValue(single, CreateSingle(propertyInfo.PropertyType));
            }
            return single;
        }

        public object CreateSingle(Type objectType)
        {
            return CreateMulti(objectType, 1).First();
        }

        public T CreateSingle<T>() where T : new()
        {
            return (T) CreateSingle(typeof (T));
        }
    }
}