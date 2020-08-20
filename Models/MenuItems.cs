using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Truyum.Models
{
    public class MenuItems
    {
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Please enter ItemName and should be 2-65 characters")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Please enter Item Price")]
        public string Price { get; set; }

        [Required(ErrorMessage = "Please select Date")]
        [DataType(DataType.Date)]
        public string Date { get; set; }

        [Required(ErrorMessage = "Please select one Category")]
        public string Category { get; set; }
      
        public string Active { get; set; }
        public string FreeDelivery { get; set; }

        
    }
}
