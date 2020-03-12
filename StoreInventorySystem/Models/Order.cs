using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreInventorySystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Order Name must contain 2 - 25 characters.")]
        public string OrderName { get; set; }
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Description must obtain 5 - 100 characters.")]
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderDueDate { get; set; }
        public double OrderPrice { get; set; }
        public double OrderBalance { get; set; }
    }
}