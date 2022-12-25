using MessagePack;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProgramingProject.Models
#nullable disable
{
    
    [Table("AspNetUsers")]
    public class MovieUser : IdentityUser
    {
        
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Surname")]
        public string Surname { get; set; }

        

    }
}
