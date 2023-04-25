using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
            Console.ReadKey();
        }
    }
    class Logging:ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    interface ILogging
    {
        void Log();
    }

    class Cashing: ICashing
    {
        public void Cash()
        {
            Console.WriteLine("Cashed");
        }
    }

    interface ICashing
    {
       void Cash();
    }

    class Authorize: IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User checked");
        }
    }

    interface IAuthorize
    {
        void CheckUser();
    }
    class CustomerManager
    {
        private CrossCuttongConcernsFacade _concerns;
        public CustomerManager()
        {
            _concerns=new CrossCuttongConcernsFacade();
        }
        public void Save()
        {

            _concerns.logging.Log();
            _concerns.cashing.Cash();
            _concerns.authorize.CheckUser();

            Console.WriteLine("Saved");
        }
    }
    class CrossCuttongConcernsFacade
    {
        public ILogging logging;
        public ICashing cashing;
        public IAuthorize authorize;
        public CrossCuttongConcernsFacade()
        {
            logging = new Logging();
            cashing=new Cashing();
            authorize=new Authorize();

        }
    }
}
