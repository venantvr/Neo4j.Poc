using Neo4jClient.Extension.Cypher;
using NeoPoc.Model;
using NeoPoc.Model.Relationships;

namespace NeoPoc.Write
{
    public class DomainMapping
    {
        private FluentConfig DomainFluentMapping => FluentConfig.Config(new CypherExtensionContext { JsonContractResolver = new PreserveCaseContractResolver() });

        public void Fluent()
        {
            DomainFluentMapping
                .With<Person>("Client")
                .Match(x => x.Reference)
                .Merge(x => x.Reference)
                .MergeOnCreate(p => p.Reference)
                .MergeOnCreate(p => p.DateCreated)
                .MergeOnMatchOrCreate(p => p.Title)
                .MergeOnMatchOrCreate(p => p.Name)
                .MergeOnMatchOrCreate(p => p.IsOperative)
                .MergeOnMatchOrCreate(p => p.Sex)
                .MergeOnMatchOrCreate(p => p.SerialNumber)
                .MergeOnMatchOrCreate(p => p.SpendingAuthorisation)
                .Set();

            DomainFluentMapping
                .With<Address>()
                .MergeOnMatchOrCreate(a => a.Street)
                .MergeOnMatchOrCreate(a => a.Suburb)
                .Set();

            DomainFluentMapping
                .With<Weapon>()
                .Match(x => x.Id)
                .Merge(x => x.Id)
                .MergeOnMatchOrCreate(w => w.Name)
                .MergeOnMatchOrCreate(w => w.BlastRadius)
                .Set();

            DomainFluentMapping
                .With<HomeAddressRelationship>()
                .Match(ha => ha.DateEffective)
                .MergeOnMatchOrCreate(hr => hr.DateEffective)
                .Set();

            DomainFluentMapping
                .With<WorkAddressRelationship>()
                .Set();
        }
    }
}