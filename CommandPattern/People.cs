using System;
namespace CommandPattern
{
    public class People : DatabaseObject
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public People(){}

        public People(String name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return "[People] {Id : " + Id + "} {Name : " + Name + "}";
        }

    }
}
