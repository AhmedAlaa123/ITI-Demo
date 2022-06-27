using Day2.Models.Courses;
using System.ComponentModel.DataAnnotations;

namespace Day2.Models.Attributes
{
    public class UniqueNameAttribute :ValidationAttribute
    {
        public int CourseId { get; set; }
        public  UniqueNameAttribute()
        {
            
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return new ValidationResult("Name Is Requird");
            }
            

            string name=value.ToString().ToLower();
            Context context = new Context();
            Course course = context.Courses.FirstOrDefault(cr => cr.Name.ToLower().Equals(name));
            
            // check if validation context is CourseInfoDTO Instance
            if (validationContext.ObjectInstance is CourseInfoDTO)
            {
                CourseInfoDTO dto = (CourseInfoDTO)validationContext.ObjectInstance;
                if (course.Id == dto.Id)
                    return ValidationResult.Success;

            }
            if (course != null)
                return new ValidationResult($"{name} Is Found Name");
            return ValidationResult.Success;
        }
    }
}
