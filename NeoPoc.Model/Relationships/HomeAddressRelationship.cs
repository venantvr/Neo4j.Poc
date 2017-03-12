using System;
using Neo4jClient.Extension.Cypher;

namespace NeoPoc.Model.Relationships
{
    public class HomeAddressRelationship : BaseRelationship
    {
        public HomeAddressRelationship(string key) : base(key)
        {
        }

        public HomeAddressRelationship(string fromKey, string toKey) : base(fromKey, toKey)
        {
        }

        public HomeAddressRelationship(string key, string fromKey, string toKey) : base(key, fromKey, toKey)
        {
        }

        public DateTime DateEffective { get; set; }
    }
}