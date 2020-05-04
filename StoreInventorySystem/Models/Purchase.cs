using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreInventorySystem.Models
{
    public class Purchase
    {
        //KEYS
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int ProductId { get; set; }

        //PROPERTIES
        [Display(Name = "Purchase Name")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "First name must contain 2 - 10 characters.")]
        public string PurchaseName { get; set; }
        [Display(Name = "Description")]
        [StringLength(75, MinimumLength = 5, ErrorMessage = "Please enter a description. 5 - 75 characters.")]
        public string PurchaseDescription { get; set; }
        public double PurchaseCostAmount { get; set; }
        public DateTime PurchaseCreated { get; set; }

        //FOREIGN VIRTUAL KEY 
        public virtual Supplier Supplier { get; set; }
        public virtual Product Product { get; set; }



    }
}