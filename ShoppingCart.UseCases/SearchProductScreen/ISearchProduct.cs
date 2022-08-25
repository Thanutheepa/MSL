using ShoppingCart.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.UseCases.SearchProductScreen
{
    public interface ISearchProduct
    {
        IEnumerable<Product> Execute(string search);
    }
}
