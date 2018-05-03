using System;
using System.Collections.Generic;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {

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

                //databaseManager.Undo(2);
                //databaseManager.Redo(2);

                /*db.Peoples.Add(people);
                var count = db.SaveChanges();

                Console.WriteLine("{0} records saved to database", count);*/

                /*User user = new User();

                user.Compute('+', 100);
                user.Compute('-', 50);
                user.Compute('*', 10);
                user.Compute('/', 2);

                // Undo 4 commands

                user.Undo(4);

                // Redo 3 commands

                user.Redo(3);

                // Wait for user


                //Console.ReadKey();
                db.Users.Add(user);
                var count = db.SaveChanges();

                Console.WriteLine("{0} records saved to database", count);
                */
            }
        }

        static void UserInteraction(){
            Console.Write("Enter to continue ...");
            Console.ReadKey();
        }
     }
}
