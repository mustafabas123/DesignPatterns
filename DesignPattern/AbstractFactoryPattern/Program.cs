using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory1());
            productManager.GetAll();
            Console.ReadLine();
        }
        public abstract class Logging
        {
            public abstract void Log(string message);
        }
        public class Log4NetLogger : Logging
        {
            public override void Log(string message)
            {
                Console.WriteLine("Logged with Log4Net");
            }
        }
        public class NLogger : Logging
        {
            public override void Log(string message)
            {
                Console.WriteLine("Logged with NLogger");
            }
        }
        public abstract class Caching
        {
            public abstract void Cache(string data);
        }
        public class MemCash : Caching
        {
            public override void Cache(string data)
            {
                Console.WriteLine("Cached with MemCash");
            }
        }

        public class RedishCash : Caching
        {
            public override void Cache(string data)
            {
                Console.WriteLine("Cached with RedishCash");
            }
        }

        public abstract class CrossCuttingConcernsFactory
        {
            public abstract Logging CreateLogger();
            public abstract Caching CreateCaching();
        }

        public class Factory1 : CrossCuttingConcernsFactory
        {
            public override Caching CreateCaching()
            {
                return new MemCash();
            }

            public override Logging CreateLogger()
            {
                return new Log4NetLogger();
            }
        }

        public class Factory2 : CrossCuttingConcernsFactory
        {
            public override Caching CreateCaching()
            {
                return new RedishCash();
            }

            public override Logging CreateLogger()
            {
                return new Log4NetLogger();
            }
        }
        public class ProductManager
        {
            private readonly Logging _logger;
            private readonly Caching _caching;
            private readonly CrossCuttingConcernsFactory _crossCuttingConcernsFactory;
            public ProductManager(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
            {
                _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
                _caching=_crossCuttingConcernsFactory.CreateCaching();
                _logger = _crossCuttingConcernsFactory.CreateLogger();
            }

            public void GetAll()
            {
                _logger.Log("Logged");
                _caching.Cache("Data");
                Console.WriteLine("Product List");
            }
        }
    }
}
