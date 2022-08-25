using ShoppingCart.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.UseCases.FavProductScreen
{
    public interface IFavProduct
    {
        void SetFav(List<Product> products);
        List<Product> GetFavProducts();
        void AddToFav(Product product);
        List<Product> RemoveFromFav(Product product);
        void EmptyFav();

        int GetTotalCount();
        bool IsAdded(Product product);
    }
}
