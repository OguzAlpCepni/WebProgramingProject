using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebProgramingProject.Models
{
    public class Person:BaseModel
    {
        
        public string Name { get; set; }
        
        public string LastName { get; set; }
        
        public int Age { get; set; }
        
        public string Photo { get; set; }
    }
}
