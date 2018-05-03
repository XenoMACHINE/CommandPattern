using System;
namespace CommandPattern
{
    public class CarUpdateCommand : Command
    {
        private Car car;
        private Car newCar;
        private DBContext dBContext = DatabaseManager.GetInstance();

        public CarUpdateCommand(Car car, String brand = null, String model = null)
        {
            this.car = car;
            newCar = new Car(car);
            if (brand != null) newCar.brand = brand;
            if (model != null) newCar.model = model;
            newCar.Id = car.Id;
        }

        public override void Execute()
        {
            Console.WriteLine("\n" + this + "\n");
            var tmpCar = new Car(car);
            var dbCar = dBContext.Cars.Find(car.Id);
            dbCar.brand = newCar.brand;
            dbCar.model = newCar.model;
            dBContext.SaveChanges();
            newCar = tmpCar;
        }

        public override void UnExecute()
        {
            Execute();
        }

        public override string ToString()
        {
            return "[CarUpdateCommand] Update   " + car + "\n\t\t\t to " + newCar;
        }
    }
}
