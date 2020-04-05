using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreInventorySystem.Models
{
    public class InventoryItem
    {
        //key
        public int Id { get; set; }
        public string OrderId { get; set; }

        //properties 
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Title must contain 2 - 30 characters.")]
        public string ItemName { get; set; }
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Description must contain at least 5 - 100 characters.")]
        public string ItemDescription { get; set; }
        public double ItemPrice { get; set; }
        


    }
}