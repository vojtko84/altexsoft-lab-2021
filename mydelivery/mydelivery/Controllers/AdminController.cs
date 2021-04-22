using Mydelivery.Data;
using Mydelivery.Models;
using System;
using System.Collections.Generic;

namespace Mydelivery.Controllers
{
    public class AdminController
    {
        private readonly Context context;

        private readonly Admin admin;

        public AdminController(Admin admin, Context context)
        {
            this.admin = admin;
            this.context = context;
        }

        public void ViewSelectedCategory()
        {
            Console.WriteLine("Choose a category for viewing");
            Console.WriteLine("1. Buyers\n2. Sellers\n3. Categories\n4. Products");
            var userChoise = Console.ReadLine();

            switch (userChoise)
            {
                case "1":
                    View(context.Buyers);
                    break;

                case "2":
                    View(context.Sellers);
                    break;

                case "3":
                    View(context.Categories);
                    break;

                case "4":
                    View(context.Products);
                    break;

                default:
                    throw new NullReferenceException();
            }
        }

        private void View(IList<Buyer> buyers)
        {
            foreach (var item in buyers)
            {
                Console.WriteLine($"{item.Id}. {item.FirstName} {item.LastName}");
            }
        }

        private void View(IList<Seller> sellers)
        {
            foreach (var item in sellers)
            {
                Console.WriteLine($"{item.Id}. {item.Name}");
            }
        }

        private void View(IList<Category> categories)
        {
            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Id}. {item.Name}");
            }
        }

        private void View(IList<Product> products)
        {
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Id} {item.Name}");
            }
        }

        public void CreateCategory()
        {
            var category = new Category();
            category.Id = context.Categories.Count + 1;
            Console.WriteLine("Enter category name");
            category.Name = Console.ReadLine();
            context.Categories.Add(category);
            context.Save();
        }
    }
}