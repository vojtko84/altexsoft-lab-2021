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
            task2Linq.Task1();
            task2Linq.Task2();
            task2Linq.Task3();
            task2Linq.Task4();
            task2Linq.Task5();

            Console.ReadKey();
        }
    }
}