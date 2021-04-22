using Mydelivery.Data;
using Mydelivery.Models;
using System;
using System.Linq;

namespace Mydelivery.Controllers
{
    public class BuyerController
    {
        protected readonly Buyer buyer;
        protected readonly Context context;

        public BuyerController(Buyer buyer, Context context)
        {
            this.buyer = buyer;
            this.context = context;
        }

        public void ShowAllProducts()
        {
            foreach (var item in context.Products)
            {
                Console.WriteLine($"{item.Id}. {item.Name} Price {item.Price}");
            }
        }

        public void CreateOrder()
        {
            var order = new Order();
            order.Id = context.Orders.Count + 1;
            order.BuyerId = 1;
            Console.WriteLine("Choose a product");
            ShowAllProducts();
            int userChoise;
            while (!int.TryParse(Console.ReadLine(), out userChoise))
            {
                Console.Write("Incorrect input, enter number: ");
            }
            var selectedProduct = context.Products.ElementAt(userChoise - 1);

            order.Products.Add(selectedProduct);
            order.DeliveryAddress = new DeliveryAddress();
            Console.WriteLine("Please provide the shipping address");
            Console.WriteLine("Enter house number");
            order.DeliveryAddress.HouseNumber = Console.ReadLine();
            Console.WriteLine("Enter street name");
            order.DeliveryAddress.StreetName = Console.ReadLine();
            Console.WriteLine("Enter apartment number");
            order.DeliveryAddress.ApartmentNumber = Console.ReadLine();
            Console.WriteLine("Enter city name");
            order.DeliveryAddress.CityName = Console.ReadLine();
            Console.WriteLine("Enter area name");
            order.DeliveryAddress.AreaName = Console.ReadLine();
            Console.WriteLine("Enter PostCode");
            order.DeliveryAddress.PostCode = Console.ReadLine();

            order.DeliveryAddress.Id = context.DeliveryAddresses.Count + 1;
            order.DeliveryAddress.BuyerId = 1;
            context.Orders.Add(order);
            context.DeliveryAddresses.Add(order.DeliveryAddress);
            context.Save();
        }
    }
}