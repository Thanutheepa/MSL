using ShoppingCart.CoreBusiness.Models;
using ShoppingCart.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppinCart.DataStore
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products;

        public ProductRepository()
        {
            products = new List<Product>
            {
                //new Product{ ProductId=1, Name="40\" LED HD TV HX40N2173F", Price=48000.00, Qty=20, Image="https://giggles.lk/images/I159343644090280HX40N2173F-1000x1000.png" ,Description="Hisense 40\" full hd tv -HX40N2173FResolution 1920 X 1080HDMI 03AV in 01USB 023D Digital Comb FilterHead Phone-01Earphone JackLength – 903mm | Width – 563mm | Height – 208mm"},
                //new Product{ ProductId=2, Name="Multimedia Sound System IMS 03", Price=10900.00, Qty=5, Image="https://giggles.lk/images/I159133667879837ims03.jpg" ,Description="1 Year Warranty . Super Sounds. MULTIMEDIA AUDIO SYSTEM IMS 03 • 350W PMPO • FM Radio • Bluetooth & AUX connectivity • USB/ SD • Volume & Bass Control • 7 Colors Pulsating LED"},
                //new Product{ ProductId=3, Name="Double door Refrigerator 180Ltr with base DDR 195", Price=48900.00, Qty=15, Image="https://giggles.lk/images/I159127766225571innovex-refrigerators-ddr195-1000x1000%20(1).jpg" ,Description="Direct cool , with Lock, 10 Years warranty."},
                //new Product{ ProductId=4, Name="2.1 Multimedia Sound System", Price=12500.00, Qty=25, Image="https://giggles.lk/images/I159133711382313FB_IMG_1558522429387.jpg" ,Description="1 Year Warranty. Super Sounds. MULTIMEDIA AUDIO SYSTEM • 650W PMPO • FM Radio • Bluetooth & AUX connectivity • USB/ SD • Volume, Treble & Bass Control"},
                //new Product{ ProductId=5, Name="9mm SUPER CHAMPION CARROM BOARD", Price=6900.00, Qty=15, Image="https://giggles.lk/images/I162978238861861Super-Champion-C006-2.jpg" ,Description="9mm SUPER CHAMPION 🏆CARROM BOARD, FULL LENGTH: 33\" × 33\", INSIDE BOARD LENGTH: 28\"x 28\", INSIDE BOARD THICKNESSES: 9mm, FRAME THICKNESSES:  4cm, INSIDE BUFFING MALAYSIAN BOARD, SMOOTH AND EASY TO PLAY, FREE 24PCS CARROM COINS, FREE DISC "},
            };
        }

        public Product GetProduct(int productId)
        {
            return products.FirstOrDefault(product => product.productId == productId);
        }

        public IEnumerable<Product> GetProducts(string search)
        {
            if (search == String.Empty)
                return products;
            else
                return products.Where(product => product.name.ToLower().Contains(search.ToLower()));
        }
    }
}
