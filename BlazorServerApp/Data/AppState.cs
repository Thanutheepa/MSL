using ShoppingCart.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerApp.Data
{
    public class AppState
    {
        public int selectedOutletId = 1;
        public int cartItemCount { get; private set; }
        public User user { get; private set; }

        public int favProductCount { get; private set; }
        public string decision { get; private set; }
        public string currType { get; private set; }
        public Rate currRate { get; private set; }

        public event Action OnChange;

        public void SetOutlet(int outletId)
        {
            selectedOutletId = outletId;
            NotifyStateChanged();
        }
        public void SetCartItemCount(int count)
        {
            cartItemCount = count;
            NotifyStateChanged();
        }
        public void SetUser(User user)
        {
            this.user = user;
            NotifyStateChanged();
        }

        public void SetFavProductCount(int count)
        {
            favProductCount = count;
            NotifyStateChanged();
        }
        public void SetDecision(string des)
        {
            decision = des;
            NotifyStateChanged();
        }
        public void SetCurrType(string type)
        {
            currType = type;
            NotifyStateChanged();
        }
        public void SetCurrRate(Rate rate)
        {
            currRate = rate;
            NotifyStateChanged();
        }
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
