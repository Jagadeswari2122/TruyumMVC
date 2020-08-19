using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Truyum.Models;

namespace Truyum.Repository
{
    interface ICustomerRepository
    {
        public void AddToCart(MenuItems item);
        public List<Cart> GetItemsInCart();
        public void DeleteItemInCart(int id);
        public Cart GetCartItemById(int? cartId);
    }
}
