using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StoreInventorySystem.Helpers;

namespace StoreInventorySystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    
    public class ApplicationUser : IdentityUser
    {
        //Application User properties
        [Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must contain 2 - 20 characters.")]
        public string FirstName { get; set; }
        [Display(Name= "Last Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must contain 2 - 20 characters.")]
        public string LastName { get; set; }
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Display Name must contain 4 - 25 characters.")]
        public string DisplayName { get; set; }
        public string AvatarPath { get; set; }
        //first and last name concatinated
        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        //FOREIGN KEY VIRTUAL CONNECTIONS
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Product> Products { get; set; }


        //CONSTRUCTOR
        public ApplicationUser()
        {
            Orders = new HashSet<Order>();
            Products = new HashSet<Product>();
            Purchases = new HashSet<Purchase>();

        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //this will lock out demo roles from making changes
        //public override int SaveChanges()
        //{
        //    UserRolesHelper role = new UserRolesHelper();

        //    var userId = HttpContext.Current.User.Identity.GetUserId();
        //    if (role.IsDemoUser(userId))
        //    {
        //        try
        //        {
        //            return base.SaveChanges();
        //        }
        //        catch (DbEntityValidationException ex)
        //        {
        //            DEBUGING ENTITYVALIDATIONERRORS CODE HERE
        //        }
        //    }
        //    return 0;
        //}

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        public System.Data.Entity.DbSet<StoreInventorySystem.Models.Order> Orders { get; set; }
        public System.Data.Entity.DbSet<StoreInventorySystem.Models.OrderPriority> OrderPriorities{get;set;}
        public System.Data.Entity.DbSet<StoreInventorySystem.Models.OrderStatus> OrderStatus { get; set; }
        public System.Data.Entity.DbSet<StoreInventorySystem.Models.Product> Products { get; set; }
        public System.Data.Entity.DbSet<StoreInventorySystem.Models.Purchase> Purchases { get; set; }
        public System.Data.Entity.DbSet<StoreInventorySystem.Models.Supplier> Suppliers { get; set; }


    }
}