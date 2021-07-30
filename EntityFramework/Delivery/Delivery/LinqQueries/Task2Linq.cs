using System;
using System.Collections.Generic;
using System.Linq;
using Delivery.Data;
using Delivery.Models;

namespace Delivery.LinqQueries
{
    public class Task2Linq
    {
        private readonly TestContext _context;

        public Task2Linq(TestContext context)
        {
            _context = context;
        }

        public void Task1()
        {
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Task1:");
            Console.WriteLine(new string('-', 30));
            var sortProducts = _context.Products.OrderBy(p => p.Name).Select(p => p.Name);
            foreach (var item in sortProducts)
            {
                Console.WriteLine($"- {item}");
            }
        }

        public void Task2()
        {
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Task2:");
            Console.WriteLine(new string('-', 30));
            var providerProducts = _context.Products.Join(_context.Providers,
                                                          p => p.ProviderId,
                                                          pr => pr.Id,
                                                          (p, pr) => new
                                                          {
                                                              ProviderName = pr.Name,
                                                              ProductName = p.Name,
                                                          });
            foreach (var item in providerProducts)
            {
                Console.WriteLine($"- Provider: {item.ProviderName} | Product: {item.ProductName}");
            }
        }

        public void Task3()
        {
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Task3:");
            Console.WriteLine(new string('-', 30));
            var categories = _context.Categories.GroupJoin(_context.Products,
                                                           c => c.Id,
                                                           p => p.CategoryId,
                                                           (c, p) => new
                                                           {
                                                               CategoryName = c.Name,
                                                               ProductsCount = p.Count()
                                                           });
            foreach (var item in categories)
            {
                Console.WriteLine($"Categoy: {item.CategoryName}\nProduct quantity: {item.ProductsCount}\n");
            }
        }

        public void Task4()
        {
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Task4:");
            Console.WriteLine(new string('-', 30));
            var providers = _context.Providers.GroupJoin(_context.Products,
                                                         prv => prv.Id,
                                                         prd => prd.ProviderId,
                                                         (prv, prd) => new
                                                         {
                                                             ProviderName = prv.Name,
                                                             ProductsCount = prd.Count()
                                                         }).OrderByDescending(c => c.ProductsCount);
            foreach (var item in providers)
            {
                Console.WriteLine($"Provider: {item.ProviderName}\nProduct quantity: {item.ProductsCount}\n");
            }
        }

        public void Task5()
        {
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Task5:");
            Console.WriteLine(new string('-', 30));
            var products1 = _context.Products.Where(p => p.ProviderId == 1);
            var products2 = _context.Products.Where(p => p.ProviderId == 2);
            var similarProducts = products1.Intersect(products2, new ProductComparer()).ToList();
            Console.WriteLine("Similar products:");
            foreach (var item in similarProducts)
            {
                Console.WriteLine($"- {item.Name}");
            }

            var uniqueProducts1 = products1.Except(products2, new ProductComparer()).ToList();
            var uniqueProducts2 = products2.Except(products1, new ProductComparer()).ToList();
            var uniqueProducsTotal = new List<Product>();
            uniqueProducsTotal.AddRange(uniqueProducts1);
            uniqueProducsTotal.AddRange(uniqueProducts2);
            var providerProducts = uniqueProducsTotal.Join(_context.Providers,
                                                        p => p.ProviderId,
                                                        pr => pr.Id,
                                                        (p, pr) => new
                                                        {
                                                            ProviderName = pr.Name,
                                                            ProductName = p.Name,
                                                        });
            Console.WriteLine("\nUnique products:");
            foreach (var item in providerProducts)
            {
                Console.WriteLine($"- {item.ProductName} | {item.ProviderName}");
            }
        }
    }
}