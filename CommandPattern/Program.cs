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
                People people = new People(name: "Alex");
                People people2 = new People(name: "Michel");
                User user = new User();
                user.Compute('+', 100);

                DatabaseManager databaseManager = new DatabaseManager();
                databaseManager.Compute("insert", people);
                //databaseManager.Compute("insert", people2);
                //databaseManager.Compute("insert", user);
                Console.ReadKey();
                //databaseManager.Compute("delete", people);
                databaseManager.Undo(1);

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
    }
}
