using System;
namespace CommandPattern
{
    public class Car : DatabaseObject
    {
        public int Id { get; set; }
        public string brand { get; set; }
        public string model { get; set; }

        public Car(){}

        public Car(String brand, String model)
        {
            this.brand = brand;
            this.model = model;
        }

        public Car(Car car){
            this.Id = car.Id;
            this.brand = car.brand;
            this.model = car.model;
        }

        public Car(Boolean userinteraction){
            Console.WriteLine("Creating new Car Object...");
            Console.Write("Brand : ");
            this.brand = Console.ReadLine();
            Console.Write("Model : ");
            this.model = Console.ReadLine();
        }

        public override string ToString()
        {
            return "[Car] {Id : " + Id + "} {Brand : " + brand + "} {Model : " + model + "}";
        }
    }
}