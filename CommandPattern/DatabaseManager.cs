using System;
using System.Collections.Generic;

namespace CommandPattern
{
    public class DatabaseManager
    {

        private List<Command> _commands = new List<Command>();
        private Crud _crud = new Crud();
        public int _current = 0;

        public void ShowCommands(){
            Console.WriteLine("Current : " + _current);
            var i = 0;
            foreach (Command command in _commands){
                Console.Write(i + " - ");
                Console.WriteLine(command);
                i++;
            }
        }

        public void Redo(int levels = 1)
        {
            Console.WriteLine("\n---- Redo {0} levels ", levels);
            // Perform redo operations

            for (int i = 0; i < levels; i++)
            {
                if (_current < _commands.Count)
                {
                    Command command = _commands[_current++];
                    command.Execute();
                }
            }
            ShowCommands();
        }

        public void Undo(int levels = 1)
        {
            Console.WriteLine("\n---- Undo {0} levels ", levels);
            // Perform undo operations

            for (int i = 0; i < levels; i++)
            {
                if (_current > 0)
                {
                    Command command = _commands[--_current] as Command;
                    command.UnExecute();
                }
            }
            ShowCommands();
        }

        public void Request(string type, DatabaseObject databaseObject)
        {
            // Create command operation and execute it
            Command command = new CrudCommand(_crud, type, databaseObject);
            command.Execute();

            // Add command to undo list
            _commands.Add(command);
            _current++;
            ShowCommands();
        }
    }

    class CrudCommand : Command {

        private Crud _crud;
        private string _type;
        private DatabaseObject _databaseObject;

        public CrudCommand(Crud crud, string type, DatabaseObject databaseObject){
            this._crud = crud;
            this._type = type;
            this._databaseObject = databaseObject;

            //Console.WriteLine(databaseObject.GetType().GetProperties());
        }

        public string Type{
            set { _type = value; }
        }

        public DatabaseObject DatabaseObject{
            set { _databaseObject = value; }
        }
        
        public override void Execute(){
            _crud.Operation(_type, _databaseObject);
        }

        public override void UnExecute(){
            _crud.Operation(Undo(_type), _databaseObject);
        }

        private string Undo(string type)
        {
            switch (type)
            {
                case "insert": return "delete";
                case "delete": return "insert";
                default:
                    throw new

            ArgumentException("type");
            }
        }

        public override string ToString()
        {
            return "[CrudCommand] Crud -"/* + _crud */+ " Type " + _type + " dbObject " + _databaseObject;
        }
    }

    class Crud{

        public void Operation(string type, DatabaseObject databaseObject){
            switch (type.ToLower())
            {
                case "insert":
                    Insert(databaseObject);
                    break;

                case "delete":
                    Delete(databaseObject);
                    break;
            }
        }

        private void Insert(DatabaseObject databaseObject){
            Console.WriteLine("Insert {0}", databaseObject);

            using (var db = new DBContext())
            {
                if (databaseObject is People){
                    db.Peoples.Add((People)databaseObject);
                }
                if (databaseObject is Car)
                {
                    db.Cars.Add((Car)databaseObject);
                }
                var count = db.SaveChanges();
                //Console.WriteLine("{0} records saved to database", count);
            }
        }

        private void Delete(DatabaseObject databaseObject)
        {
            Console.WriteLine("Delete {0}", databaseObject);

            using (var db = new DBContext())
            {
                if (databaseObject is People)
                {
                    db.Peoples.Remove((People)databaseObject);
                }
                if (databaseObject is Car)
                {
                    db.Cars.Remove((Car)databaseObject);
                }
                var count = db.SaveChanges();
                //Console.WriteLine("{0} records saved to database", count);
            }
        }
    }
}
