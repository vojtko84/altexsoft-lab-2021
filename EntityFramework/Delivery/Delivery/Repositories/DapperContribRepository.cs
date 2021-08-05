using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper.Contrib.Extensions;
using Delivery.Models;

namespace Delivery.Repositories
{
    public class DapperContribRepository : IRepository
    {
        private readonly IDbConnection db;

        public DapperContribRepository(string connectionString)
        {
            db = new SqlConnection(connectionString);
        }

        public int AddCategory(Category category)
        {
            var newCategory = db.Insert<Category>(category);
            return (int)newCategory;
        }

        public int AddCategoryWithObjects(Category category)
        {
            var newCategory = db.Insert<Category>(category);
            if (category.Products.Count != 0)

                foreach (var product in category.Products)
                {
                    product.CategoryId = (int)newCategory;
                }
            var products = db.Insert(category.Products);

            return (int)newCategory;
        }

        public bool DeleteCategory(int id)
        {
            var isSuccess = db.Delete(new Category { Id = id });
            return isSuccess;
        }

        public bool DeleteCategoryWithObjects(int id)
        {
            var category = GetCategoryByIdWithObjects(id);
            if (category?.Products != null)
            {
                foreach (var product in category.Products)
                {
                    db.Delete(new Product { Id = product.Id });
                }
            }
            var isSuccess = db.Delete(new Category { Id = id });
            return isSuccess;
        }

        public Category GetCategoryById(int id)
        {
            return db.Get<Category>(id);
        }

        public Category GetCategoryByIdWithObjects(int id)
        {
            var category = db.Get<Category>(id);
            var products = db.GetAll<Product>().Where(p => p.CategoryId == id).ToList();
            if (products.Count != 0)
            {
                category.Products = products;
            }
            return category;
        }

        public List<Category> GetCategories()
        {
            return db.GetAll<Category>().ToList();
        }

        public List<Category> GetCategoriesWithObjects()
        {
            var categories = db.GetAll<Category>().ToList();
            foreach (var category in categories)
            {
                var products = db.GetAll<Product>().Where(p => p.CategoryId == category.Id).ToList();
                category.Products = products;
            }
            return categories;
        }

        public bool UpdateCategory(Category category)
        {
            var isSuccess = db.Update(category);
            return isSuccess;
        }
    }
}