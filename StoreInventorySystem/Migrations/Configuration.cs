namespace StoreInventorySystem.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using StoreInventorySystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Configuration;

    internal sealed class Configuration : DbMigrationsConfiguration<StoreInventorySystem.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(StoreInventorySystem.Models.ApplicationDbContext context)
        {
            
            //=============================================CREATING ROLE, USER AND ASSIGNING ROLES
            #region ROLE CREATION
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }
            if (!context.Roles.Any(r => r.Name == "Manager"))
            {
                roleManager.Create(new IdentityRole { Name = "Manager" });
            }
            #endregion

            #region CREATING USER
            //adminuser
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //Creating Admin
            if (!context.Users.Any(u => u.Email == "rhernandezroberto@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "rhernandezroberto@Gmail.com",
                    Email = "rhernandezroberto@Gmail.com",
                    FirstName = "Roberto",
                    LastName = "Hernandez",
                    DisplayName = "Admin",
                    AvatarPath = "/Content/Avatars/profile_placeholder.png"
                }, WebConfigurationManager.AppSettings["adminPassword"]);
            }
            //manageruser
            if (!context.Users.Any(u => u.Email == "olimoreno1969@Gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "olimoreno1969@Gmail.com",
                    Email = "olimoreno1969@Gmail.com",
                    FirstName = "Olivia",
                    LastName = "Moreno",
                    DisplayName = "Manager",
                    AvatarPath = "/Content/Avatars/profile_placeholder.png"
                }, WebConfigurationManager.AppSettings["managerPassword"]);
            }

            //context.SaveChanges();
            #endregion

            #region ASSIGNING ROLE
            var adminId = userManager.FindByEmail("rhernandezroberto@Gmail.com").Id;
            userManager.AddToRole(adminId, "Admin");

            var managerId = userManager.FindByEmail("olimoreno1969@gmail.com").Id;
            userManager.AddToRole(managerId, "Manager");            
            #endregion

            #region SEEDING IN STATUS AND PRIORITY
            //orderStatus
            context.OrderStatus.AddOrUpdate(
                o => o.OrderStatusName,
                    new OrderStatus { OrderStatusName = "Order Processing", OrderStatusDescription = "Order has been submitted and is being processed." },
                    new OrderStatus { OrderStatusName = "Order On-Hold", OrderStatusDescription = "Order has been placed on hold." },
                    new OrderStatus { OrderStatusName = "Order Completed", OrderStatusDescription = "Order has been completed and turned in to customer." },
                    new OrderStatus { OrderStatusName = "Order Cancelled", OrderStatusDescription = "Order has been cancelled." },
                    new OrderStatus { OrderStatusName = "Order Refunded", OrderStatusDescription = "Order has been refunded." },
                    new OrderStatus { OrderStatusName = "Order Traded", OrderStatusDescription = "Order has been traded in for another item." }
                );
            //orderPriority
            context.OrderPriorities.AddOrUpdate(
                o => o.PriorityName,
                    new OrderPriority { PriorityName = "Urgent", PriorityDescription = "URGENT: PLEASE FULLFILL ORDER IMMEDIATELY." },
                    new OrderPriority { PriorityName = "High", PriorityDescription = "HIGH: LEVEL IS HIGH AND SHOULD BE FULLFILLED SOON." },
                    new OrderPriority { PriorityName = "Medium", PriorityDescription = "MEDIUM: ORDER IS IN PROCESS." },
                    new OrderPriority { PriorityName = "Low", PriorityDescription = "LOW: ORDER PENDING." }
                );
            #endregion

        }
    }
}
