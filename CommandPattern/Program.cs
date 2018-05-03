using System;
using System.Collections.Generic;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            DatabaseManager databaseManager = new DatabaseManager();

            using (var db = DatabaseManager.GetInstance())
            {
                Car car = new Car("Mercedes", "Classe B");

                db.showAll();

                databaseManager.ExecCommand(new CarInsertCommand(car));
                db.showAll();
                UserInteraction();

                databaseManager.Undo();
                db.showAll();
                UserInteraction();
            }
        }

        static void Version1(){
            using (var db = new DBContext())
            {
                db.showAll();

                People people = new People(name: "Alex");

                Car car = new Car("Mercedes", "Classe A");

                DatabaseManager databaseManager = new DatabaseManager();
                databaseManager.Request("insert", people);

                UserInteraction();
                databaseManager.Undo();

                UserInteraction();
                databaseManager.Redo();

                UserInteraction();
                databaseManager.Request("insert", car);

                UserInteraction();
                databaseManager.Undo(2);
            }
        }

        static void UserInteraction(){
            Console.Write("Enter to continue ...");
            Console.ReadKey();
        }
     }
}
