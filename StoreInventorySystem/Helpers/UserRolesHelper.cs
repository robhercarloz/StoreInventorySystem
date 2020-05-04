using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StoreInventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreInventorySystem.Helpers
{
    public class UserRolesHelper
    {

        private UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>
            (new UserStore<ApplicationUser>(new ApplicationDbContext()));

        private ApplicationDbContext db = new ApplicationDbContext();

        //IS USER IN ROLE DEMO
        public bool IsDemoUser(string userId)
        {
            return userManager.GetRoles(userId).FirstOrDefault().Contains("Demo");
        }
        //ADD USER TO ROLE 
        public bool AddUserToRole(string userId, string roleName)
        {
            var result = userManager.AddToRole(userId, roleName);
            return result.Succeeded;
        }
    }
}