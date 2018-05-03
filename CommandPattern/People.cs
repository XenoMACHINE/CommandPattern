using System;
namespace CommandPattern
{
    public class People : DatabaseObject
    {

        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }

        public People(){}

        public People(String lastname, String firstname)
        {
            this.Lastname = lastname;
            this.Firstname = firstname;
        }

        public People(People people)
        {
            this.Id = people.Id;
            this.Lastname = people.Lastname;
            this.Firstname = people.Lastname;
        }

        public People(Boolean userinteraction)
        {
            Console.WriteLine("Updating People Object...");
            Console.Write("Lastname : ");
            this.Lastname = Console.ReadLine();
            Console.Write("Firstname : ");
            this.Firstname = Console.ReadLine();
        }

        public People askUpdate()
        {
            var newPeople = new People(this);
            Console.WriteLine("Updating People Object...");
            Console.Write("Lastname (" + this.Lastname + ") : ");
            newPeople.Lastname = Console.ReadLine();
            Console.Write("Firstname (" + this.Firstname + ") : ");
            newPeople.Firstname = Console.ReadLine();

            return newPeople;
        }

        public override string ToString()
        {
            return "[People] {Id : " + Id + "} {Lastname : " + Lastname + "}" + "} {Firstname : " + Firstname + "}";
        }

    }
}
