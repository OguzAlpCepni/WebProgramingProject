using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebProgramingProject.Models
{
    public class MoviePerson:BaseModel
    {
        [Display(Name = "movie")]
        public Movie Movie { get; set; }

        [Display(Name = "person")]
        public Person Person { get; set; }
       
        public string Role  { get; set; }
    }
}
