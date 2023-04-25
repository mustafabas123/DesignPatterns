using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var customerManager = CustomerManager.CreateAsSingleton();
			customerManager.Save();
		}
	}

	class CustomerManager
	{
		private static CustomerManager customerManager;
		static object _lockObject=new object(); //bir dumpy nedene ürettik 
		/// <summary>
		/// CustomerManager ' ı dış erişime engelemektir private oluşturmamızın nedeni
		/// </summary>
		private CustomerManager() 
		{

		}
		/// <summary>
		/// Eğer customer manager nesinesi yok ise yani null ise bir customerMAnager nesnesi üret var ise geçmişte üretilenni döndür
		/// </summary>
		/// <returns></returns>
		public static CustomerManager CreateAsSingleton()
		{
			lock (_lockObject) // bu kodun altındaki işelmni bir kere emin olmak için böyle bir kod bloğuna ihtiyaç duyuyoruz
			{
				if (customerManager == null) //return customerManager ?? (customerManager = new CustomerManager()); bu kod bloğuyla bu aynı şey 
				{
					customerManager = new CustomerManager();
				}
			}
			return customerManager;
		}
		public void Save()
		{
			Console.WriteLine("Kaydet");
		}
	}
}
