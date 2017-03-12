using System;
using System.Configuration;
using Neo4jClient;
using Neo4jClient.Cypher;
using Neo4jClient.Extension.Cypher;
using NeoPoc.Model;
using NeoPoc.Model.Relationships;
using NeoPoc.Write;

namespace NeoPoc.Console
{
    internal class Program
    {
        private static void Main()
        {
            new DomainMapping().Fluent();

            var url = ConfigurationManager.AppSettings["Neo4jUrl"];
            var user = ConfigurationManager.AppSettings["Neo4jUser"];
            var password = ConfigurationManager.AppSettings["Neo4jPassword"];

            using (var client = new GraphClient(new Uri(url), user, password))
            {
                client.Connect();

                for (var i = 0; i < 10; i++)
                {
                    var agent = new Person
                                {
                                    Reference = i,
                                    Title = $"Toto_{i}",
                                    Name = $"Toto_{i}",
                                    HomeAddress = new Address { Street = $"Home_{i}" },
                                    WorkAddress = new Address { Street = $"Work_{i}" }
                                };

                    var q = new CypherFluentQuery<Person>(client, new QueryWriter())
                        .CreateEntity(agent, "a")
                        .CreateEntity(agent.HomeAddress, "ha")
                        .CreateEntity(agent.WorkAddress, "wa")
                        .CreateRelationship(new HomeAddressRelationship("a", "ha"))
                        .CreateRelationship(new WorkAddressRelationship("a", "wa"));

                    System.Console.WriteLine(q.Query.DebugQueryText);

                    q.ExecuteWithoutResults();
                }
            }

            using (var client = new GraphClient(new Uri("http://192.168.1.79:7474/db/data/"), "neo4j", "corbak74"))
            {
                client.Connect();

                //var read_ok = client.Cypher
                //    .Match("(n:Client)")
                //    .Where((Person n) => n.Name == @"Toto_0")
                //    .Return(n => n.As<Person>());

                var searchPattern = new Person { Name = @"Toto_0" };
                var read = new CypherFluentQuery<Person>(client, new QueryWriter())
                    .MatchEntity(searchPattern)
                    .Return(person => person.As<Person>());

                System.Console.WriteLine(read.Query.DebugQueryText);

                // ReSharper disable once UnusedVariable
                var results = read.Results;
            }
        }
    }
}