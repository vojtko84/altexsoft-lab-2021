using Mydelivery.Data;
using Mydelivery.Models;
using System;
using System.Collections.Generic;

namespace Mydelivery.Controllers
{
    public class SellerController
    {
        private readonly Seller seller;
        private readonly Context context;

        public void PostProduct()
        {
            var product = new Product();
            product.Id = context.Products.Count + 1;
            Console.WriteLine("Enter product name");
            product.Name = Console.ReadLine();
            Console.WriteLine("Enter descriptionb");
            product.Description = Console.ReadLine();
            Console.WriteLine("Enter category");
            Console.WriteLine("Select a product category.");
            foreach (var item in context.Categories)
            {
                Console.WriteLine($"{item.Id} {item.Name}.");
            }
            product.CategoryId = context.Categories.Count + 1;
            decimal price;
            Console.WriteLine("Enter price");
            while (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.Write("Incorrect input, enter number: ");
            }
            product.Price = price;

            product.SallerId = 1; //TODO
            context.Products.Add(product);
            context.Save();
        }

        public IList<Product> GetProducts()
        {
            return context.Products;
        }

        public SellerController(Seller seller, Context context)
        {
            this.seller = seller;
            this.context = context;
        }
    }
}