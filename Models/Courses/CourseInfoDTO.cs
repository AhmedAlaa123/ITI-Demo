using Day2.Models.Attributes;
using Day2.Models.Departments;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Day2.Models.Courses
{
    public class CourseInfoDTO
    {
        public int Id { get; set; }

        [UniqueName]
        [Required(ErrorMessage = "*Course Name Is Required")]
        [MaxLength(20, ErrorMessage = "*Max Lenght Of Name Must Be 20")]
        [MinLength(2, ErrorMessage = "*Minimum Lenght Of Name Must Be 20")]
        public string Name { get; set; }
        [Display(Name = "Course Degree :")]
        [Required(ErrorMessage = "*Course Degree Is Required")]
        [Range(minimum: 50, maximum: 100, ErrorMessage = "*Degree must be in 50 : 100")]
        public int Degree { get; set; }

        [Display(Name = "Course Minmum Degree : ")]
        [Required(ErrorMessage = "*Course Minmum Degree Is Required")]

        [Remote(action: "ValidateDegree", controller: "Course", AdditionalFields = "Degree", ErrorMessage = "Degree Must be greater Than Minimum Degree")]
       
        public int MinDegree { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "*Department Is Required")]
        public int Dept_Id { get; set; }
        public DepartmentInfoDTO? Department { get; set; }
    }
}
