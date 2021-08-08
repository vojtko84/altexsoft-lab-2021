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

        public List<Product> Task1()
        {
            var sortedProducts = _context.Products.OrderBy(p => p.Name).ToList();
            return sortedProducts;
        }

        public List<(string ProviderName, string ProductName)> Task2()
        {
            var providerProducts = _context.Products.Join(_context.Providers,
                                                          p => p.ProviderId,
                                                          pr => pr.Id,
                                                          (p, pr) => new
                                                          {
                                                              ProviderName = pr.Name,
                                                              ProductName = p.Name,
                                                          });
            return providerProducts.Select(p => (ProviderName: p.ProviderName, ProductName: p.ProductName)).ToList();
        }

        public List<(Category Category, int ProductsCount)> Task3()
        {
            var categories = _context.Categories.GroupJoin(_context.Products,
                                                           c => c.Id,
                                                           p => p.CategoryId,
                                                           (c, p) => new
                                                           {
                                                               Category = c,
                                                               ProductsCount = p.Count()
                                                           });
            return categories.Select(c => (Category: c.Category, ProductsCount: c.ProductsCount)).ToList();
        }

        public List<Category> Task3_1()
        {
            var categories = _context.Categories.GroupJoin(_context.Products,
                                                           c => c.Id,
                                                           p => p.CategoryId,
                                                           (c, p) => new Category() { Id = c.Id, Name = c.Name, Products = p.ToList() }
                                                           );
            return categories.ToList();
        }

        public List<Provider> Task4()
        {
            var providers = _context.Providers.GroupJoin(_context.Products,
                                                         prv => prv.Id,
                                                         prd => prd.ProviderId,
                                                         (prv, prd) => new
                                                         {
                                                             Provider = prv,
                                                             ProductsCount = prd.Count()
                                                         }).OrderByDescending(c => c.ProductsCount)
                                                         .Select(p => p.Provider).ToList();
            return providers;
        }

        public List<Product> Task5_1()
        {
            var products1 = _context.Products.Where(p => p.ProviderId == 1);
            var products2 = _context.Products.Where(p => p.ProviderId == 2);
            var similarProducts = products1.Intersect(products2, new ProductComparer());

            return similarProducts.ToList();
        }

        public List<(Product Product, Provider Provider)> Task5_2()
        {
            var products1 = _context.Products.Where(p => p.ProviderId == 1);
            var products2 = _context.Products.Where(p => p.ProviderId == 2);
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
                                                            Provider = pr,
                                                            Product = p,
                                                        });

            return providerProducts.Select(p => (Product: p.Product, Provider: p.Provider)).ToList();
        }
    }
}