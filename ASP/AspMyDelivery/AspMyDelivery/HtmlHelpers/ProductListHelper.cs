using System.Collections.Generic;
using AspMyDelivery.API.ViewModels;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspMyDelivery.API.HtmlHelpers
{
    public static class ProductListHelper
    {
        public static HtmlString CreateListProduct(this IHtmlHelper html, IEnumerable<ProductViewModel> products)
        {
            var result = "<ul>";
            foreach (var item in products)
            {
                result = $"{result}<li>{item.Name} {item.Description} {item.Price}</li>";
            }
            result = $"{result}</ul>";
            return new HtmlString(result);
        }
    }
}