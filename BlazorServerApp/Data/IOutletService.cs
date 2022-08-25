using ShoppingCart.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerApp.Data
{
    public interface IOutletService
    {
        Task<Token> GetToken();
        Task<IEnumerable<Outlet>> GetAllOutlets();
    }
}
