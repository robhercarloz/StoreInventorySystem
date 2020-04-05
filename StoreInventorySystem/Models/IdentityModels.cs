using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace StoreInventorySystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //Application User properties
        [Display(Name = "First Name")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "First name must contain 2 - 20 characters.")]
        public string FirstName { get; set; }
        [Display(Name= "Last Name")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Last name must contain 2 - 20 characters.")]
        public string LastName { get; set; }
        [StringLength(25, MinimumLength = 4, ErrorMessage = "Display Name must contain 4 - 25 characters.")]
        public string DisplayName { get; set; }
        public string AvaterPath { get; set; }
        //first and last name concatinated
        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName}{LastName}";
            }
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
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}