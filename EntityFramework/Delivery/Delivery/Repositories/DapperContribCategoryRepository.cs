using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper.Contrib.Extensions;
using Delivery.Models;

namespace Delivery.Repositories
{
    public class DapperContribCategoryRepository : IRepository
    {
        private readonly IDbConnection _db;

        public DapperContribCategoryRepository(string connectionString)
        {
            _db = new SqlConnection(connectionString);
        }

        public int AddCategory(Category category)
        {
            var newCategory = _db.Insert<Category>(category);
            return (int)newCategory;
        }

        public int AddCategoryWithObjects(Category category)
        {
            var newCategory = _db.Insert<Category>(category);
            if (category.Products != null)
            {
                foreach (var product in category.Products)
                {
                    product.CategoryId = (int)newCategory;
                    var products = _db.Insert(category.Products);
                }
            }

            return (int)newCategory;
        }

        public bool DeleteCategory(int id)
        {
            var isSuccess = _db.Delete(new Category { Id = id });
            return isSuccess;
        }

        public bool DeleteCategoryWithObjects(int id)
        {
            var category = GetCategoryByIdWithObjects(id);
            if (category?.Products != null)
            {
                foreach (var product in category.Products)
                {
                    _db.Delete(new Product { Id = product.Id });
                }
            }
            var isSuccess = _db.Delete(new Category { Id = id });
            return isSuccess;
        }

        public Category GetCategoryById(int id)
        {
            return _db.Get<Category>(id);
        }

        public Category GetCategoryByIdWithObjects(int id)
        {
            var category = _db.Get<Category>(id);
            var products = _db.GetAll<Product>().Where(p => p.CategoryId == id).ToList();
            if (products.Count != 0)
            {
                category.Products = products;
            }
            return category;
        }

        public List<Category> GetCategories()
        {
            return _db.GetAll<Category>().ToList();
        }

        public List<Category> GetCategoriesWithObjects()
        {
            var categories = _db.GetAll<Category>().ToList();
            foreach (var category in categories)
            {
                var products = _db.GetAll<Product>().Where(p => p.CategoryId == category.Id).ToList();
                category.Products = products;
            }
            return categories;
        }

        public bool UpdateCategory(Category category)
        {
            var isSuccess = _db.Update(category);
            return isSuccess;
        }
    }
}