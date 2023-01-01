using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
#nullable disable
namespace WebProgramingProject.Models
{
    public class MoviePerson:BaseModel
    {
        public int MovieId { get; set; }
        [Display(Name = "movie")]
        public Movie Movie { get; set; }

        public int PersonId { get; set; }
        [Display(Name = "person")]
        public Person Person { get; set; }
       
        public string Role  { get; set; }
    }
}
