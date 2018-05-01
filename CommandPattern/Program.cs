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
                User user = new User();

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
            }
        }
    }
}
