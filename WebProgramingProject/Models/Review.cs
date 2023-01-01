using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
#nullable disable
namespace WebProgramingProject.Models
{
    public class Review:BaseModel
    {
        public int MovieUserId { get; set; }
        [Display(Name = "kisi")]
        public MovieUser MovieUser { get; set; }

        public int MovieId { get; set; }
        [Display(Name = "movie")]
        public Movie Movie { get; set; }
        
        public double Rating { get; set; }
        
        public string Comment { get; set; }

    }
}
