using System;
using System.Collections.Generic;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            DatabaseManager databaseManager = new DatabaseManager();
            var db = DatabaseManager.GetInstance();

            Car car = new Car("Mercedes", "Classe B");

            db.showAll();

            databaseManager.ExecCommand(new CarInsertCommand(car));
            db.showAll();
            UserInteraction();

            databaseManager.ExecCommand(new CarDeleteCommand(car));
            db.showAll();
            UserInteraction();

            databaseManager.Undo();
            db.showAll();
            UserInteraction();

            databaseManager.Undo();
            db.showAll();
            UserInteraction();

            databaseManager.Redo(-1);
            db.showAll();
            UserInteraction();
        }

        static void UserInteraction(){
            Console.Write("Enter to continue ...");
            Console.ReadKey();
        }
     }
}
