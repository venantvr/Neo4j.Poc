using Neo4jClient.Extension.Cypher;

namespace NeoPoc.Model.Relationships
{
    public class WorkAddressRelationship : BaseRelationship
    {
        public WorkAddressRelationship(string key) : base(key)
        {
        }

        public WorkAddressRelationship(string fromKey, string toKey) : base(fromKey, toKey)
        {
        }

        public WorkAddressRelationship(string key, string fromKey, string toKey) : base(key, fromKey, toKey)
        {
        }
    }
}