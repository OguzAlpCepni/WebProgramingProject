using Microsoft.AspNetCore.Identity;

namespace WebProgramingProject.Models
{
    public class AppRole : IdentityRole
    {
        public AppRole() : base() { }
        public AppRole(String name) : base(name) { }
    }
}
