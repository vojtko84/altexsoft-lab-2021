using System.Collections.Generic;
using Delivery.Models;

namespace Delivery.Data
{
    public class TestContext
    {
        public IList<Category> Categories { get; set; }
        public IList<Product> Products { get; set; }
        public IList<Provider> Providers { get; set; }

        public TestContext()
        {
            GetTestContext();
        }

        private void GetTestContext()
        {
            Categories = new List<Category> { new Category { Id = 1, Name = "TVs"},
                                              new Category { Id = 2, Name = "Phones"},
                                              new Category { Id = 3, Name = "Laptops"}
                                            };
            Providers = new List<Provider> { new Provider { Id = 1, Name = "Rozetka"},
                                             new Provider { Id = 2, Name = "Allo"},
                                             new Provider { Id = 3, Name = "Amazon"}
                                           };
            Products = new List<Product> { new Product { Id = 1, Name = "iPhone X", CategoryId = 2, Description = "Apple iPhone X", ProviderId = 1, Price = 1000M },
                                           new Product { Id = 2, Name = "iPhone X", CategoryId = 2, Description = "Apple iPhone X", ProviderId = 2, Price = 900M },
                                           new Product { Id = 3, Name = "iPhone 9", CategoryId = 2, Description = "Apple iPhone 9", ProviderId = 3, Price = 700M },
                                           new Product { Id = 4, Name = "iPhone 9", CategoryId = 2, Description = "Apple iPhone 9", ProviderId = 1, Price = 800M },
                                           new Product { Id = 5, Name = "LG 43UP75006LF", CategoryId = 1, Description = "LG 43UP75006LF", ProviderId = 1, Price = 650M },
                                           new Product { Id = 6, Name = "LG 43UP75006LF", CategoryId = 1, Description = "LG 43UP75006LF", ProviderId = 2, Price = 650M },
                                           new Product { Id = 7, Name = "LG 43UP75006LF", CategoryId = 1, Description = "LG 43UP75006LF", ProviderId = 3, Price = 750M },
                                           new Product { Id = 8, Name = "Xiaomi Mi TV UHD 4S", CategoryId = 1, Description = "Xiaomi Mi TV UHD 4S", ProviderId = 1, Price = 650M },
                                           new Product { Id = 9, Name = "QE55Q60AAUXUA", CategoryId = 1, Description = "QE55Q60AAUXUA", ProviderId = 2, Price = 650M },
                                           new Product { Id = 10, Name = "LG OLED55C14LB", CategoryId = 1, Description = "LG OLED55C14LB", ProviderId = 2, Price = 650M },
                                           new Product { Id = 11, Name = "LG OLED55C14LB", CategoryId = 1, Description = "LG OLED55C14LB", ProviderId = 3, Price = 2000M },
                                           new Product { Id = 12, Name = "QE55Q60AAUXUA", CategoryId = 1, Description = "QE55Q60AAUXUA", ProviderId = 1, Price = 1100M },
                                           new Product { Id = 13, Name = "Apple New MacBook Air M1", CategoryId = 3, Description = "Apple New MacBook Air M1", ProviderId = 1, Price = 1100M },
                                           new Product { Id = 14, Name = "Apple New MacBook Air M1", CategoryId = 3, Description = "Apple New MacBook Air M1", ProviderId = 2, Price = 1200M },
                                           new Product { Id = 15, Name = "Apple New MacBook Air M1", CategoryId = 3, Description = "Apple New MacBook Air M1", ProviderId = 3, Price = 1100M },
                                           new Product { Id = 16, Name = "Lenovo IdeaPad 3 15IGL", CategoryId = 3, Description = "Lenovo IdeaPad 3 15IGL", ProviderId = 1, Price = 800M },
                                           new Product { Id = 17, Name = "Acer Swift 1 SF114-34", CategoryId = 3, Description = "Acer Swift 1 SF114-34", ProviderId = 2, Price = 550M },
                                           new Product { Id = 18, Name = "Acer Swift 1 SF114-34", CategoryId = 3, Description = "Acer Swift 1 SF114-34", ProviderId = 3, Price = 600M },
                                           new Product { Id = 19, Name = "Asus X515JF-EJ082 Grey", CategoryId = 3, Description = "Asus X515JF-EJ082 Grey", ProviderId = 1, Price = 500M },
                                         };
        }
    }
}