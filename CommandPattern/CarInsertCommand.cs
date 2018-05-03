using System;
namespace CommandPattern
{
    public class CarInsertCommand : Command
    {
        private Car car;
        private String type;

        public CarInsertCommand(Car car){
            this.car = car;
        }
        
        public override void Execute()
        {
            using (var db = new DBContext())
            {
                type = "Insert";
                db.Cars.Add(car);
                db.SaveChanges();
            }
        }

        public override void UnExecute()
        {
            using (var db = new DBContext())
            {
                type = "Delete";
                db.Cars.Remove(car);
                db.SaveChanges();
            }
        }

        public override string ToString()
        {
            return "[CarInsertCommand] " + type + " " + car;
        }
    }
}
