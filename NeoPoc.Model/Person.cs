using System;

namespace NeoPoc.Model
{
    public class Person
    {
        public int Reference { get; set; }
        public DateTime DateCreated { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public bool IsOperative { get; set; }
        public int Sex { get; set; }
        public string SerialNumber { get; set; }
        public bool SpendingAuthorisation { get; set; }
        public Address HomeAddress { get; set; }
        public Address WorkAddress { get; set; }
    }
}