using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreInventorySystem.Models
{
    public class OrderStatus
    {
        //KEYS
        public int Id { get; set; }

        //PROPERTIES
        [Display(Name = "Status Name")]
        //[StringLength(30, MinimumLength = 3, ErrorMessage = "Please enter a status Name.")]
        public string OrderStatusName { get; set; }
        [Display(Name = "Status Description")]
        //[StringLength(50, MinimumLength = 3, ErrorMessage = "Please enter in a description.")]
        public string OrderStatusDescription { get; set; }

        //CHILD
        public virtual ICollection<Order> Orders { get; set; }

        //CONSTRUCTOR
        public OrderStatus()
        {
            Orders = new HashSet<Order>();
        }
    }
}