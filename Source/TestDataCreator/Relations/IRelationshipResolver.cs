using System;

namespace TestDataCreator.Relations
{
    public interface IRelationshipResolver
    {
        Relation ResolveRelation(Type from, Type to);
    }
}