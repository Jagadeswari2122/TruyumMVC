using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Truyum.Models;

namespace Truyum.Repository
{
    interface IAdminRepository
    {
        public List<MenuItems> GetAllItems();
        public void AddItem(MenuItems item);
        public void UpdateItem(MenuItems item);
        public MenuItems GetItemById(int? id);

        public void DeleteItem(int id);


    }
}
