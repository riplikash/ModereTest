using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Student
    {
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }


    }
}