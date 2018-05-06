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

        //Copy constructor
        public People(People people)
        {
            this.Id = people.Id;
            this.Lastname = people.Lastname;
            this.Firstname = people.Firstname;
        }

        //Constructor with user interaction
        public People(Boolean userinteraction)
        {
            Console.WriteLine("Updating People Object...");
            Console.Write("Lastname : ");
            this.Lastname = Console.ReadLine();
            Console.Write("Firstname : ");
            this.Firstname = Console.ReadLine();
        }

        // Update object method with user interaction
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
