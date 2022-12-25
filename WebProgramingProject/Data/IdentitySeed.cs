using Microsoft.AspNetCore.Identity;
using System;
using WebProgramingProject.Models;

namespace WebProgramingProject.Data
{
    public class IdentitySeed
    {
        public static async Task InitializeUsersAsync(UserManager<MovieUser> userManager, RoleManager<AppRole> roleManager)
        {
            var defaultUsers = new MovieUser[] {
                new MovieUser
                {
                    UserName = "Oguz Alp",
                    Email = "g201210035@sakarya.edu.tr",
                    Name = "Oguz alp",
                    Surname = "Cepni",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                },
                new MovieUser
                {
                    UserName = "Mustafa",
                    Email = "g211210380@sakarya.edu.tr",
                    Name = "Mustafa",
                    Surname = "Bebek",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                }
            };
            foreach (var defaultUser in defaultUsers)
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123");
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Customer.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Employee.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.SuperAdmin.ToString());
                }
            }

        }
        public static async Task InitializeRolesAsync(UserManager<MovieUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (roleManager.Roles.Count() == 0)
            {
                await roleManager.CreateAsync(new AppRole(Enums.Roles.SuperAdmin.ToString()));
                await roleManager.CreateAsync(new AppRole(Enums.Roles.Admin.ToString()));
                await roleManager.CreateAsync(new AppRole(Enums.Roles.Employee.ToString()));
                await roleManager.CreateAsync(new AppRole(Enums.Roles.Customer.ToString()));
            }
        }
        internal async static void Initialize(IServiceProvider applicationServices)
        {
            using (var scope = applicationServices.CreateScope())
            {
                var provider = scope.ServiceProvider;
                var context = provider.GetRequiredService<MovieDbContext>();
                var userManager = provider.GetRequiredService<UserManager<MovieUser>>();
                var roleManager = provider.GetRequiredService<RoleManager<AppRole>>();

                // automigration 
                await InitializeRolesAsync(userManager, roleManager);
                await InitializeUsersAsync(userManager, roleManager);
            }
        }
    }
}
