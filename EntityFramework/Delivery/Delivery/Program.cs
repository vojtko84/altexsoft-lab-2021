using System;
using Delivery.Data;
using Delivery.LinqQueries;

namespace Delivery
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var context = new TestContext();
            var task2Linq = new Task2Linq(context);

            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Task1:");
            Console.WriteLine(new string('-', 30));
            foreach (var item in task2Linq.Task1())
            {
                Console.WriteLine($"- {item.Name}");
            }

            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Task2:");
            Console.WriteLine(new string('-', 30));
            foreach (var item in task2Linq.Task2())
            {
                Console.WriteLine($"- Provider: {item.ProviderName} | Product: {item.ProductName}");
            }

            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Task3:");
            Console.WriteLine(new string('-', 30));
            foreach (var item in task2Linq.Task3())
            {
                Console.WriteLine($"Category: {item.Category.Name}\nProduct quantity: {item.ProductsCount}\n");
            }

            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Task3_1:");
            Console.WriteLine(new string('-', 30));
            foreach (var item in task2Linq.Task3_1())
            {
                Console.WriteLine($"Category: {item.Name}\nProduct quantity: {item.Products.Count}\n");
            }

            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Task4:");
            Console.WriteLine(new string('-', 30));
            foreach (var item in task2Linq.Task4())
            {
                Console.WriteLine($"Provider: {item.Name}");
            }

            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Task5_1:");
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Similar products:");
            foreach (var item in task2Linq.Task5_1())
            {
                Console.WriteLine($"- {item.Name}");
            }

            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Task5_2:");
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Unique products:");
            foreach (var item in task2Linq.Task5_2())
            {
                Console.WriteLine($"- {item.Product.Name} | {item.Provider.Name}");
            }

            Console.ReadKey();
        }
    }
}