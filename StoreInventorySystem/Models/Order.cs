using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreInventorySystem.Models
{
    public class Order
    {
        //KEYS
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderPriorityId { get; set; }
        public int OrderStatusId { get; set; }
        public string OrderOwnerId { get; set; }

        //PROPERTIES
        [Display(Name = "Order Name")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Enter in Name between 3 - 30 characters")]
        public string OrderName { get; set; }
        [Display(Name = "Order Description")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Enter in description  5 - 50 characters")]
        public string OrderDescription { get; set; }
        public int OrderQuantity { get; set; }
        public DateTime OrderCreated { get; set; }
        public DateTime OrderDue { get; set; }

        //FOREIGN KEY VIRTUALS
        public virtual OrderPriority OrderPriority { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual ApplicationUser OrderOwner { get; set; }
        public virtual Product Product { get; set; }





    }
}