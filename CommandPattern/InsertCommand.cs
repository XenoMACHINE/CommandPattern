using System;
namespace CommandPattern
{
    class InsertCommand : Command
    {
        private Crud _crud;

        public InsertCommand(Crud crud)
        {
            this._crud = crud;
        }

        public override void Execute()
        {
            //_crud.Operation("insert");
        }

        public override void UnExecute()
        {
            //_crud.Operation("delete");
        }
    }
}
