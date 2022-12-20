using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
#nullable disable
namespace WebProgramingProject.Models
{
    public class Movie :BaseModel
    {
        [Required]
        public string MovieName { get; set; }
        [Required]
        public string Explain { get; set; }
        [Display(Name = "category")]
        public Category Category { get; set; }

    }
}
