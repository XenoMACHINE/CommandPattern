using System;
using System.Collections.Generic;

namespace CommandPattern
{
    class Program
    {
        static DatabaseManager databaseManager = new DatabaseManager();
        static DBContext db = DatabaseManager.GetInstance();

        static void Main(string[] args)
        {
            MenuManager menuManager = new MenuManager(databaseManager, db);
            menuManager.ShowMenu();
        }
     }
}
