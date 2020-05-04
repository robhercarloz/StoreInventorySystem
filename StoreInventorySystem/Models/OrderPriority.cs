using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreInventorySystem.Models
{
    public class OrderPriority
    {
        //KEYS
        public int Id { get; set; }

        //PROPERTIES 
        [Display(Name = "Priority Name")]
        //[StringLength(30, MinimumLength = 3, ErrorMessage = "Please enter a name.")]
        public string PriorityName { get; set; }
        [Display(Name = "Priority Description")]
        //[StringLength(50, MinimumLength = 5, ErrorMessage = "Please give description.")]
        public string PriorityDescription { get; set; }

        //CHILD
        public virtual ICollection<Order> Orders { get; set; }

        //CONSTRUCTOR
        public OrderPriority()
        {
            Orders = new HashSet<Order>();
        }
    }
}