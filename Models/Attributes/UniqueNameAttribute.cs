using System.ComponentModel.DataAnnotations;

namespace Day2.Models.Attributes
{
    public class UniqueNameAttribute :ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return new ValidationResult("Name Is Requird");
            }

            string name=value.ToString().ToLower();
            Context context = new Context();
            Course course = context.Courses.FirstOrDefault(cr => cr.Name.ToLower().Equals(name));
            if (course != null)
                return new ValidationResult($"{name} Is Found Name");
            return ValidationResult.Success;
        }
    }
}
