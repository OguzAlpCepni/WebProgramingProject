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
        
        
        [Display(Name = "Slider Fotoğraf Adresi")]
        public string SliderPhotoURL { get; set; }

        [Display(Name = "Detay Fotoğraf Adresi")]
        public string DetailPhotoURL { get; set; }

        public ICollection<Category> Categories { get; set;}
        public ICollection<Review> Reviews { get; set;}
        public ICollection<MoviePerson> Persons { get; set;}
    }
}
