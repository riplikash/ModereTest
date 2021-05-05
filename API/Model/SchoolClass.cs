using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class SchoolClass
    {

        // GroupId - int id of group of clients
        [Required]
        public string Name { get; set; }

        private IEnumerable<Student> Students { get; set; }
    }
}
