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
            
            AskRemoveAll();
            db.showAll();

            ShowMenu();
            /*
            Car car = new Car(userinteraction: true);//new Car("Mercedes", "Classe B");

            databaseManager.ExecCommand(new CarInsertCommand(car));
            db.showAll();
            UserInteraction();

            databaseManager.ExecCommand(new CarUpdateCommand(car, model: "Classe C"));
            db.showAll();
            UserInteraction();

            databaseManager.Undo();
            db.showAll();
            UserInteraction();

            databaseManager.Undo();
            db.showAll();
            UserInteraction();

            databaseManager.Redo();
            db.showAll();
            UserInteraction();

            databaseManager.Redo();
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
            UserInteraction();*/
        }

        static void UserInteraction(){
            Console.Write("Enter to continue ...");
            Console.ReadKey();
        }

        static void AskRemoveAll(){
            Console.Write("Do you want to clean database ? (y/n) : ");
            ConsoleKeyInfo result = Console.ReadKey();
            Console.WriteLine("");
            if (result.KeyChar == 'y' || result.KeyChar == 'Y'){
                DatabaseManager.GetInstance().RemoveAll();
            }
        }

        static char GetResult(){
            Console.Write("Tape your choice : ");
            ConsoleKeyInfo result = Console.ReadKey();
            Console.WriteLine("");
            return result.KeyChar;
        }

        static void ShowMenu(){
            Console.WriteLine("########### MENU ###########\n" +
                              "#    Insert object : i     #\n" +
                              "#    Update object : u     #\n" +
                              "#    Remove object : r     #\n" +
                              "#     Undo (back) : b      #\n" +
                              "#     Redo (next) : n      #\n" +
                              "#   Show Database : space  #\n" +
                              "############################\n");

            var key = GetResult();
            switch (key)
            {
                case 'i':
                    InsertObject();
                    break;
                case 'u':
                    break;
                case 'r':
                    break;
                case 'b':
                    break;
                case 'n':
                    break;
                case ' ':
                    db.showAll();
                    break;
            }

            ShowMenu();
        }

        static void InsertObject(){
            Console.WriteLine("####### CREATE OBJECT #######\n" +
                              "#         1. People         #\n" +
                              "#          2. Car           #\n" +
                              "#############################\n");

            var key = GetResult();
            switch (key){
                case '1':
                    var people = new People(true);
                    break;
                case '2':
                    var car = new Car(true);
                    databaseManager.ExecCommand(new CarInsertCommand(car));
                    break;
            }
        }


     }
}
