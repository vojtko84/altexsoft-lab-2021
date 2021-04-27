using System.Collections.Generic;
using Mydelivery.Models;

namespace Mydelivery.Interfaces
{
    public interface ICategoryController
    {
        IList<Category> GetCategories();

        void AddCategory(string name);
    }
}