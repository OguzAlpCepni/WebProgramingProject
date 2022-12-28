using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;
using WebProgramingProject.Models;


namespace WebProgramingProject.Data
{
    public class IdentitySeed
    {
        

        public void InitializeUsersAsync()
        {

            var defaultUsers = new MovieUser[] {
                new MovieUser
                {
                    UserName = "g211210380@sakarya.edu.tr",
                    Email = "g211210380@sakarya.edu.tr",
                    Name = "Mustafa",
                    Surname = "Bebek",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                },
                new MovieUser
                {
                    UserName = "g201210035@sakarya.edu.tr",
                    Email = "g201210035@sakarya.edu.tr",
                    Name = "Oguz alp",
                    Surname = "Cepni",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                },
            };
            

            foreach (var defaultUser in defaultUsers)
            {
                var user = this.userManager.FindByEmailAsync(defaultUser.Email).Result;
                if (user == null)
                {
                    _userStore.SetUserNameAsync(defaultUser, defaultUser.UserName, CancellationToken.None).Wait();
                    _emailStore.SetEmailAsync(defaultUser, defaultUser.Email, CancellationToken.None).Wait(); 

                    var t = userManager.CreateAsync(defaultUser, "sau").Result;

                    user = this.userManager.FindByEmailAsync(defaultUser.Email).Result;
                    if (user == null)
                        continue;
                    this.userManager.AddToRoleAsync(user, Enums.Roles.Customer.ToString()).Wait();
                    this.userManager.AddToRoleAsync(user, Enums.Roles.Employee.ToString()).Wait();
                    this.userManager.AddToRoleAsync(user, Enums.Roles.Admin.ToString()).Wait();
                    this.userManager.AddToRoleAsync(user, Enums.Roles.SuperAdmin.ToString()).Wait();
                }
            }

        }
        public void InitializeRolesAsync()
        {
            if (this.roleManager.Roles.Count() == 0)
            {
                this.roleManager.CreateAsync(new AppRole(Enums.Roles.SuperAdmin.ToString())).Wait();
                this.roleManager.CreateAsync(new AppRole(Enums.Roles.Admin.ToString())).Wait();
                this.roleManager.CreateAsync(new AppRole(Enums.Roles.Employee.ToString())).Wait();
                this.roleManager.CreateAsync(new AppRole(Enums.Roles.Customer.ToString())).Wait();
            }
        }
        public void Initialize()
        {
            // automigration 
            this.InitializeRolesAsync();
            this.InitializeUsersAsync();
        }


        private RoleManager<AppRole> roleManager;
        private UserManager<MovieUser> userManager;
        private readonly IUserStore<MovieUser> _userStore;
        private readonly IUserEmailStore<MovieUser> _emailStore;
        public IdentitySeed(RoleManager<AppRole> roleManager, UserManager<MovieUser> userManager, IUserStore<MovieUser> _userStore)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this._emailStore = (IUserEmailStore<MovieUser>)_userStore;
            this._userStore = _userStore;
        }
        


    }
}
