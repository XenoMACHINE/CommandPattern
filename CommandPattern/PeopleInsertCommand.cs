using System;
namespace CommandPattern
{
    public class PeopleInsertCommand : Command
    {
        private People people;
        private String type;
        private DBContext dBContext = DatabaseManager.GetInstance();

        public PeopleInsertCommand(People people)
        {
            this.people = people;
        }

        public override void Execute()
        {
            type = "Insert";
            dBContext.Peoples.Add(people);
            dBContext.SaveChanges();
            Console.WriteLine("\n" + this + "\n");
        }

        public override void UnExecute()
        {
            type = "Delete";
            dBContext.Peoples.Remove(people);
            dBContext.SaveChanges();
            Console.WriteLine("\n" + this + "\n");
        }

        public override string ToString()
        {
            return "[PeopleInsertCommand] " + type + " " + people;
        }
    }
}
