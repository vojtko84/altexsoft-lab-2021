using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Delivery.Models;

namespace Delivery.Repositories
{
    public class DapperRepository : IRepository
    {
        private readonly IDbConnection db;

        public DapperRepository(string connectionString)
        {
            db = new SqlConnection(connectionString);
        }

        public int AddCategory(Category category)
        {
            var sql = "INSERT INTO [dbo].[Categories] ([Name]) VALUES (@Name)";
            var affectedRows = db.Execute(sql, category);
            var categories = db.Query<Category>($"SELECT * FROM [dbo].[Categories] WHERE Name = '{category.Name}'").ToList();
            var id = categories.LastOrDefault().Id;
            return id;
        }

        public int AddCategoryWithObjects(Category category)
        {
            var sql = "INSERT INTO [dbo].[Products] ([Name], [Description], [Price], [CategoryId], [ProviderId]) VALUES (@Name, @Description, @Price, @CategoryId, @ProviderId)";
            AddCategory(category);
            var categories = db.Query<Category>($"SELECT * FROM [dbo].[Categories] WHERE Name = '{category.Name}'").ToList();
            var id = categories.LastOrDefault().Id;
            if (category.Products.Count != 0)
            {
                foreach (var product in category.Products)
                {
                    product.CategoryId = id;
                    var affectedRows = db.Execute(sql, product);
                }
            }
            return id;
        }

        public bool DeleteCategory(int id)
        {
            var sql = "DELETE FROM [dbo].[Categories] WHERE Id = @Id";
            var affectedRows = db.Execute(sql, new { Id = id });
            return affectedRows > 0;
        }

        public bool DeleteCategoryWithObjects(int id)
        {
            var category = GetCategoryByIdWithObjects(id);
            var sql = "DELETE FROM [dbo].[Products] WHERE Id = @Id";

            foreach (var product in category.Products)
            {
                var affectedRows = db.Execute(sql, new { Id = product.Id });
            }
            return DeleteCategory(id);
        }

        public Category GetCategoryById(int id)
        {
            var sql = "SELECT * FROM [dbo].[Categories] WHERE Id = @Id";
            return db.Query<Category>(sql, new { Id = id }).SingleOrDefault();
        }

        public Category GetCategoryByIdWithObjects(int id)
        {
            var sql = "SELECT * FROM [dbo].[Categories] LEFT JOIN [dbo].[Products] ON [dbo].[Categories].Id = [dbo].[Products].CategoryId WHERE [dbo].[Categories].Id = @Id";
            var dictionary = new Dictionary<int, Category>();
            var multires = db.Query<Category, Product, Category>(sql, (category, product) =>
                                                                {
                                                                    if (!dictionary.TryGetValue(category.Id, out Category cat))
                                                                    {
                                                                        cat = category;
                                                                        dictionary.Add(cat.Id, cat);
                                                                    }
                                                                    cat.Products.Add(product);
                                                                    return cat;
                                                                },
                                                                param: new { Id = id },
                                                                splitOn: "Id")
                                                                .Distinct().ToList();

            return multires.First();
        }

        public List<Category> GetCategories()
        {
            var sql = "SELECT* FROM [dbo].[Categories]";
            return db.Query<Category>(sql).ToList();
        }

        public List<Category> GetCategoriesWithObjects()
        {
            var sql = "SELECT * FROM [dbo].[Categories] LEFT JOIN [dbo].[Products] ON [dbo].[Categories].Id = [dbo].[Products].CategoryId";
            var dictionary = new Dictionary<int, Category>();
            var multires = db.Query<Category, Product, Category>(sql, (category, product) =>
                                                            {
                                                                if (!dictionary.TryGetValue(category.Id, out Category cat))
                                                                {
                                                                    cat = category;
                                                                    dictionary.Add(cat.Id, cat);
                                                                }
                                                                cat.Products.Add(product);
                                                                return cat;
                                                            },
                                                                splitOn: "Id")
                                                                .Distinct().ToList();

            return multires;
        }

        public bool UpdateCategory(Category category)
        {
            var sql = "UPDATE [dbo].[Categories] SET Name = @Name WHERE Id = @Id";
            var affectedRows = db.Execute(sql, category);
            return affectedRows > 0;
        }
    }
}