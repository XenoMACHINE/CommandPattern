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

        public People(Boolean userinteraction)
        {
            Console.WriteLine("Creating new People Object...");
            Console.Write("Name : ");
            this.Name = Console.ReadLine();
        }

        public override string ToString()
        {
            return "[People] {Id : " + Id + "} {Name : " + Name + "}";
        }

    }
}
