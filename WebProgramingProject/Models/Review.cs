using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebProgramingProject.Models
{
    public class Review:BaseModel
    {
        [Display(Name = "kisi")]
        public Person Person { get; set; }

        [Display(Name = "movie")]
        public Movie Movie { get; set; }
        
        public double Rating { get; set; }
        
        public string Comment { get; set; }

    }
}
