using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreInventorySystem.Models
{
    public class Product
    {
        //KEYS
        public int Id { get; set; }
        
        //PROPERTIES
        [Display(Name = "First Name")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "First name must contain 2 - 10 characters.")]
        public string ProductName { get; set; }
        [Display(Name = "Description")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Description invalid. Must contain 5 - 50 characters.")]
        public string ProductDescription { get; set; }
        public int ProductStock { get; set; }
        public int ProductQuantity { get; set; }
        public double ProductPrice { get; set; }

        //FOREIGN KEY
        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Order> Orders { get; set; }



        public Product()
        {
            Orders = new HashSet<Order>();            
            Users = new HashSet<ApplicationUser>();
        }
    }

}