using ShoppingCart.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.UseCases.ViewProductScreen
{
    public interface IViewProduct
    {
        Product Execute(int productId);
    }
}
