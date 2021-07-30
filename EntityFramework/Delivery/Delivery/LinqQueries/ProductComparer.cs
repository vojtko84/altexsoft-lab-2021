using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Delivery.Models;

namespace Delivery.LinqQueries
{
    public class ProductComparer : EqualityComparer<Product>
    {
        public override bool Equals(Product x, Product y)
        {
            return x?.Name == y?.Name;
        }

        public override int GetHashCode([DisallowNull] Product obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}