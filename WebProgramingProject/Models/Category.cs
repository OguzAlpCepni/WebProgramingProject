#nullable disable
namespace WebProgramingProject.Models
{
    public class Category :BaseModel
    {
        
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
    
}
