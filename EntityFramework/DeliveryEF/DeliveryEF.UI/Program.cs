using DeliveryEF.Data;
using DeliveryEF.Data.Repositories;
using DeliveryEF.Data.UoW;
using DeliveryEF.Domain.Models;

namespace DeliveryEF.UI
{
    internal class Program
    {
        private static void Main(string[] args)
        {               
            var unitOfWork = new UnitOfWork();
            var products = unitOfWork.Products.GetAll();
            foreach (var item in products)
            {
                System.Console.WriteLine($"{item.Name}");
            }
        }
    }
}