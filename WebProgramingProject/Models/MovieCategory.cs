namespace WebProgramingProject.Models
#nullable disable
{
    public class MovieCategory:BaseModel
    {
        public Movie Movie { get; set; }
        public Category Category { get; set; }
    }
}
