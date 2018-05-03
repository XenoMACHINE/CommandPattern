using System;
namespace CommandPattern
{
    public class PeopleDeleteCommand : Command
    {
        private People people;
        private String type;
        private DBContext dBContext = DatabaseManager.GetInstance();

        public PeopleDeleteCommand(People people)
        {
            this.people = people;
        }

        public override void Execute()
        {
            type = "Delete";
            dBContext.Peoples.Remove(people);
            dBContext.SaveChanges();
            Console.WriteLine("\n" + this + "\n");
        }

        public override void UnExecute()
        {
            type = "Insert";
            dBContext.Peoples.Add(people);
            dBContext.SaveChanges();
            Console.WriteLine("\n" + this + "\n");
        }

        public override string ToString()
        {
            return "[PeopleDeleteCommand] " + type + " " + people;
        }
    }
}
