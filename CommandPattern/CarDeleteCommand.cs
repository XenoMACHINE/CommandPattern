using System;
namespace CommandPattern
{
    public class CarDeleteCommand : Command
    {
        private Car car;
        private String type;
        private DBContext dBContext = DatabaseManager.GetInstance();

        public CarDeleteCommand(Car car)
        {
            this.car = car;
        }

        public override void Execute()
        {
            type = "Delete";
            dBContext.Cars.Remove(car);
            dBContext.SaveChanges();
            Console.WriteLine("\n" + this + "\n");
        }

        public override void UnExecute()
        {
            type = "Insert";
            dBContext.Cars.Add(car);
            dBContext.SaveChanges();
            Console.WriteLine("\n"+this+"\n");
        }

        public override string ToString()
        {
            return "[CarDeleteCommand] " + type + " " + car;
        }
    }
}
