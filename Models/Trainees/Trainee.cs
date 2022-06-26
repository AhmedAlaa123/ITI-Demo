using System.ComponentModel.DataAnnotations.Schema;

namespace Day2.Models
{
    public class Trainee
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string Image { get; set; }

        public string  Address { get; set; }
        public int Grade { get; set; }

        [ForeignKey("Department")]
        public int Dep_Id { get; set; }

        public Department Department { get; set; }
        public ICollection<CourseResult>courseResults { get; set; }
}
}