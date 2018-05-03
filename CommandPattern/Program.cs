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
            ShowMenu();
        }

        static void UserInteraction(){
            Console.Write("Enter to continue ...");
            Console.ReadKey();
        }

        static void AskRemoveAll(){
            Console.Write("Do you want to clean database and undo list ? (y/n) : ");
            ConsoleKeyInfo result = Console.ReadKey();
            Console.WriteLine("");
            if (result.KeyChar == 'y' || result.KeyChar == 'Y'){
                DatabaseManager.GetInstance().RemoveAll();
                databaseManager._commands = new List<Command>();
            }
        }

        static char GetResult(){
            Console.Write("Type your choice : ");
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
                              "#    Clear Database : c    #\n" +
                              "############################\n");

            var key = GetResult();
            switch (key)
            {
                case 'i':
                    InsertObject();
                    break;
                case 'u':
                    UpdateObject();
                    break;
                case 'r':
                    RemoveObject();
                    break;
                case 'b':
                    databaseManager.Undo(ChooseUndoRedo("Undo"));
                    break;
                case 'n':
                    databaseManager.Redo(ChooseUndoRedo("Redo"));
                    break;
                case ' ':
                    db.showAll();
                    break;
                case 'c':
                    AskRemoveAll();
                    db.showAll();
                    break;
            }

            ShowMenu();
        }

        static int ChooseUndoRedo(string type){
            Console.Write("How many " + type + " ? (0 for max), press enter for just 1 : ");
            ConsoleKeyInfo result = Console.ReadKey();
            Console.WriteLine("");
            if (result.Key == ConsoleKey.Enter){
                return 1;
            }
            var intValue = (int)Char.GetNumericValue(result.KeyChar);
            return intValue;
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

        static (Char,int) SelectObject(){
            Console.WriteLine("####### SELECT OBJECT #######\n" +
                              "#         1. People         #\n" +
                              "#          2. Car           #\n" +
                              "#############################\n");

            var objectSelected = GetResult();
            switch (objectSelected)
            {
                case '1':
                    db.showPeoples();
                    break;
                case '2':
                    db.showCars();
                    break;
                default:
                    return ('0', -1);
            }

            Console.Write("Type Object Id : ");
            int value = -1;
            Int32.TryParse(Console.ReadLine(), out value);
            Console.WriteLine("");

            return (objectSelected,value);
        }

        static void UpdateObject(){

            var selectObject = SelectObject();
            var objectSelected = selectObject.Item1;
            var value = selectObject.Item2;
            if (value == -1 || objectSelected == '0'){ return; }

            switch (objectSelected)
            {
                case '1':
                    break;
                case '2':
                    Car car = db.Cars.Find(value);
                    if (car == null) { return; }
                    Car newCar = car.askUpdate();
                    databaseManager.ExecCommand(new CarUpdateCommand(car, newCar));
                    break;
                default:
                    return;
            }
        }

        static void RemoveObject()
        {
            var selectObject = SelectObject();
            var objectSelected = selectObject.Item1;
            var value = selectObject.Item2;
            if (value == -1 || objectSelected == '0') { return; }

            switch (objectSelected)
            {
                case '1':
                    break;
                case '2':
                    Car car = db.Cars.Find(value);
                    if (car == null) { return; }
                    databaseManager.ExecCommand(new CarDeleteCommand(car));
                    break;
                default:
                    return;
            }
        }

     }
}
