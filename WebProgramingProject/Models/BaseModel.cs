using System.ComponentModel.DataAnnotations;

namespace WebProgramingProject.Models
{
    public class BaseModel
    {
        [Key]
        public int Id{ get; set; }
    }
}
