using ShoppingCart.CoreBusiness.Models;
using ShoppingCart.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.UseCases.FavProductScreen
{
    public class FavProduct : IFavProduct
    {
        private readonly IFavProductRepository favRepository;

        public FavProduct(IFavProductRepository favRepository)
        {
            this.favRepository = favRepository;
        }


        public void AddToFav(Product product)
        {
            favRepository.AddToFav(product);
        }

        public void EmptyFav()
        {
            favRepository.EmptyFav();
        }

        public List<Product> GetFavProducts()
        {
            return favRepository.GetFavProducts();
        }

        public int GetTotalCount()
        {
            return favRepository.GetTotalCount();
        }

        public bool IsAdded(Product product)
        {
            return favRepository.IsAdded(product);
        }

        public List<Product> RemoveFromFav(Product product)
        {
            return favRepository.RemoveFromFav(product);
        }

        public void SetFav(List<Product> products)
        {
            this.favRepository.SetFav(products);
        }
    }
}
