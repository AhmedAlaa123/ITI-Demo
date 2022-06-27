using System.ComponentModel.DataAnnotations;

namespace Day2.Models.Departments
{
    public class DepartmentInfoDTO
    {
      
        public int Id { get; set; }
        [Display(Name="Department Name :")]
        public string? Name { get; set; }

        [Display(Name = "Manger Name :")]
        public string? MangerName { get; set; }

    }
}
