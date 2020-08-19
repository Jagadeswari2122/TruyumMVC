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
    public class AdminController : Controller
    {
        // GET: Admin

        AdminRepository admin = new AdminRepository();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddNewItem()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNewItem(MenuItems item)
        {
            if (ModelState.IsValid)
            {
                admin.AddItem(item);
                return RedirectToAction("GetAllItems");
            }
            return View(item);
        }
        [HttpGet]
        public IActionResult GetAllItems()
        {
            List<MenuItems> lstItems = new List<MenuItems>();
            lstItems = admin.GetAllItems().ToList();

            return View(lstItems);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            MenuItems item = admin.GetItemById(id);
            return View(item);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, MenuItems item)
        {
            if (ModelState.IsValid)
            {
                admin.UpdateItem(item);
                return RedirectToAction("GetAllItems");
            }
            return View(item);
        }

        [HttpGet]
        public IActionResult GetItem(int id)
        {
            MenuItems item = admin.GetItemById(id);
            return View(item);
        }

        [HttpGet]
        public IActionResult DeleteItem(int? id)
        {
            MenuItems item = admin.GetItemById(id);

            return View(item);
        }

        [HttpPost, ActionName("DeleteItem")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItem(int id)
        {
            admin.DeleteItem(id);
            return RedirectToAction("GetAllItems");
        }
    }

}