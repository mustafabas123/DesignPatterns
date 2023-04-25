using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
	/// <summary>
	/// Bu design pattern en çok kullanılan design paternlandan biridir .Yazılımda değişimi kontrol altına almak için kullanılır
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
            CustomerManager customerMager = new CustomerManager(new LoggerFactory());
			customerMager.Save();
			Console.ReadLine();
		}


		public class LoggerFactory : ILoggerFactory
		{
			public ILogger CreateLogger()
			{
				// Bussiness to decide factory
				return new MBLogger();
			}
		}

        public class LoggerFactory2 : ILoggerFactory
        {
            public ILogger CreateLogger()
            {
                // Bussiness to decide factory
                return new MBLogger();
            }
        }
        public interface ILogger
		{
			void log();
		}
		public interface ILoggerFactory
		{
			ILogger CreateLogger();

        }
		public class MBLogger : ILogger
		{
			public void log()
			{
				Console.WriteLine( "Mb logger ile loglandı");
			}
		}
		public class CustomerManager
		{
			private ILoggerFactory _loggerFactory;
			public CustomerManager(ILoggerFactory loggerFactory)
			{
				_loggerFactory = loggerFactory;
			}
			public void Save()
			{
				Console.WriteLine("Kaydedildi");
				ILogger logger=new LoggerFactory().CreateLogger();
				logger.log();
			}
		}
	}
}
