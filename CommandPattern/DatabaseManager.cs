using System;
using System.Collections.Generic;

namespace CommandPattern
{
    public class DatabaseManager
    {
        public static DBContext dBContext = GetInstance();
        public List<Command> _commands = new List<Command>();
        public int _current = 0;

        public static DBContext GetInstance(){
            if (dBContext == null){
                dBContext = new DBContext();
            }
            return dBContext;
        }

        public void ShowCommands(){
            /*Console.WriteLine("Current : " + _current);
            var i = 0;
            foreach (Command command in _commands){
                Console.Write(i + " - ");
                Console.WriteLine(command);
                i++;
            }*/
        }

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
            ShowCommands();
        }

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
            ShowCommands();
        }

        public void ExecCommand(Command command){
            
            command.Execute();

            // Add command to undo list
            _commands.Add(command);
            _current++;

            //Delete command after index of inserted Command
            for (int i = _commands.Count - 1; i >= _current ; i--){
                _commands.RemoveAt(i);
            }

            ShowCommands();
        }
    }
}
