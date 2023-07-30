using FenerGrafikSanatBeta.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace FenerGrafikSanatBeta.Helpers
{
    public static class IdentityHelpers
    {

        public static string GetEmailAdress(this IIdentity identity) //Viewlerde kullanici bilgisini displayname olarak vermek icin
        {
            var userId = identity.GetUserId();
            using (var context = new ApplicationDbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                return user.Email;
            }
        }

        public static void SeedRolesAndUsers()
        {
            var context = new ApplicationDbContext();

            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "admin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "fgsanat"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "",
                    Email = "berkaysezeer@gmail.com",
                    EmailConfirmed = true,
                };

                manager.Create(user, "");
                manager.AddToRole(user.Id, "admin");
            }
        }
    }
}