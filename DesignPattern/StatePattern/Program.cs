using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();

            ModifiedState modifiedState = new ModifiedState();
            modifiedState.DoAction(context);

            DeletedState deletedState = new DeletedState();
            deletedState.DoAction(context);

            AddedState addedState = new AddedState();
            addedState.DoAction(context);

            Console.ReadLine();
        }
    }
    interface IState
    {
        void DoAction(Context context);
    }
    class ModifiedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Modified");
        }
    }

    class DeletedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Deleted");
        }
    }

    class AddedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Added");
        }
    }


    class Context
    {
        private IState _state;
        public void SetState(IState  state)
        {
            _state = state;
        }
        public IState GetState()
        {
            return _state;
        }
    }
}
