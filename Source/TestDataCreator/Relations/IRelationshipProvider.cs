using System.Collections.Generic;

namespace TestDataCreator.Relations
{
    public interface IRelationshipProvider
    {
        IEnumerable<Relation> GetRelations();
    }
}