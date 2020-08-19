using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Truyum.Models;
using Truyum.Repository;

namespace Truyum.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        CustomerRepository customer = new CustomerRepository();
        AdminRepository admin = new AdminRepository();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetItems()
        {
            List<MenuItems> lstItems = new List<MenuItems>();
            lstItems = admin.GetAllItems().ToList();

            return View(lstItems);
        }
        [HttpGet]
        public IActionResult GetItem(int? id)
        {
            MenuItems item = admin.GetItemById(id);
            return View(item);
        }
        [HttpGet]
        public IActionResult AddToCart(int? id)
        {
            MenuItems item = customer.GetItemById(id);
            customer.AddToCart(item);
            return View(item);
        }
        [HttpGet]
        public IActionResult GetCartItems()
        {
            List<Cart> cartList = new List<Cart>();
            cartList = customer.GetItemsInCart().ToList();

            return View(cartList);
        }

        [HttpGet]
        public IActionResult DeleteCartItem(int? id)
        {
            Cart cart = customer.GetCartItemById(id);

            return View(cart);
        }

        [HttpPost, ActionName("DeleteCartItem")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCartItem(int id)
        {
            customer.DeleteItemInCart(id);
            return RedirectToAction("GetCartItems");
        }
    }

}