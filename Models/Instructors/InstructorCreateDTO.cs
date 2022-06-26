using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Day2.Models.Instructors
{
    public class InstructorCreateDTO
    {
        [Required]
        [MaxLength(20,ErrorMessage ="Not allowed more than 20 characters")]
        [MinLength(2,ErrorMessage ="Not allowed less than 2 characters")]
        public string Name { get; set; }

        [Required]
        [NotNull]
        public IFormFile ImageFile { get; set; }
        public string Image { get; set; }
        [Required]
        
        public int Salary { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Dept_Id { get; set; }
        [Required]
        public int Course_Id { get; set; }
    }
}
