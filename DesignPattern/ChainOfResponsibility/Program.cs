using System;

namespace ChainOfResponsibility
{
    // Sorumluluk zinciri
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            VicePresident vicePresident = new VicePresident();
            President president = new President();
            manager.SetSuccessor(vicePresident);
            vicePresident.SetSuccessor(president);
            Expense expense = new Expense { Detail="Eğitim",Amount=1020};
            manager.HandlerExpense(expense);
            Console.ReadKey();
        }
    }
    class Expense
    {
        public string Detail { get; set; }
        public decimal Amount { get; set; }
    }
    abstract class ExpenseHandlerBase
    {
        protected ExpenseHandlerBase _successor;
        public abstract void HandlerExpense(Expense expense);
        public void SetSuccessor(ExpenseHandlerBase successor)
        {
            _successor = successor;
        }
    }
    class Manager : ExpenseHandlerBase
    {
        public override void HandlerExpense(Expense expense)
        {
            if(100>expense.Amount)
            {
                Console.WriteLine("Manager handler the expense !");
            }
            else if(_successor != null) //bir üstü yok ise 
            {
                _successor.HandlerExpense(expense);
            }
        }
    }
    class VicePresident : ExpenseHandlerBase
    {
        public override void HandlerExpense(Expense expense)
        {
            if (100 <= expense.Amount && expense.Amount<1000)
            {
                Console.WriteLine("VicePresident handler the expense !");
            }
            else if (_successor != null) //bir üstü yok ise 
            {
                _successor.HandlerExpense(expense);
            }
        }
    }
    class President : ExpenseHandlerBase
    {
        public override void HandlerExpense(Expense expense)
        {
            if (expense.Amount > 1000)
            {
                Console.WriteLine("President handler the expense !");
            }
            else if (_successor != null) //bir üstü yok ise 
            {
                _successor.HandlerExpense(expense);
            }
        }
    }
}
