using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreInventorySystem.Models
{
    public class Supplier
    {
        //KEYS
        public int Id { get; set; }

        //PROPERTIES
        [Display(Name = "Supplier Name")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Please enter a name.")]
        public string SupplierName { get; set; }
        [Display(Name = "Phone Number")]
        public string SupplierPhoneNumber { get; set; }
        [Display(Name = "location")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Please enter a description for supplier.")]
        public string SupplierLocation { get; set; }

        


    }
}