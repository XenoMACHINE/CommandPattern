using System;
using System.Collections.Generic;

namespace CommandPattern
{

    //Manager with command List and manage them
    public class DatabaseManager
    {
        public static DBContext dBContext = GetInstance(); //Singeleton of DBContext
        public List<Command> _commands = new List<Command>(); //List of command
        public int _current = 0; //index of current command (allow X redos after many undo)

        public static DBContext GetInstance(){
            if (dBContext == null){
                dBContext = new DBContext();
            }
            return dBContext;
        }

        //Redo X times (1 default)
        public void Redo(int levels = 1)
        {
            Console.WriteLine("\n---- Redo {0} levels ", levels);
            // Perform redo operations

            if (levels == 0){
                levels = _commands.Count;
            }

            for (int i = 0; i < levels; i++)
            {
                if (_current < _commands.Count)
                {
                    Command command = _commands[_current++];
                    command.Execute();
                }
            }
        }

        //Undo X times (1 default)
        public void Undo(int levels = 1)
        {
            Console.WriteLine("\n---- Undo {0} levels ", levels);
            // Perform undo operations

            if (levels == 0)
            {
                levels = _commands.Count;
            }

            for (int i = 0; i < levels; i++)
            {
                if (_current > 0)
                {
                    Command command = _commands[--_current] as Command;
                    command.UnExecute();
                }
            }
        }

        //Launch execute method of command and increment current index
        public void ExecCommand(Command command){
            
            command.Execute();

            // Add command to undo list
            _commands.Add(command);
            _current++;

            //Delete command after index of inserted Command
            for (int i = _commands.Count - 1; i >= _current ; i--){
                _commands.RemoveAt(i);
            }

        }
    }
}
