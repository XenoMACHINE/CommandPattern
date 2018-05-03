using System;
namespace CommandPattern
{
    public class PeopleUpdateCommand : Command
    {
        private People people;
        private People newPeople;
        private DBContext dBContext = DatabaseManager.GetInstance();

        public PeopleUpdateCommand(People people, People newPeople)
        {
            this.people = people;
            this.newPeople = newPeople;
        }

        public override void Execute()
        {
            Console.WriteLine("\n" + this + "\n");
            var tmpPeople = new People(people);
            var dbPeople = dBContext.Peoples.Find(people.Id);
            dbPeople.Firstname = newPeople.Firstname;
            dbPeople.Lastname = newPeople.Lastname;
            dBContext.SaveChanges();
            newPeople = tmpPeople;
        }

        public override void UnExecute()
        {
            Execute();
        }

        public override string ToString()
        {
            return "[PeopleUpdateCommand] Update   " + people + "\n\t\t\t to " + newPeople;
        }
    }
}
