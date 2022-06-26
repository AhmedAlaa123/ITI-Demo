using System.ComponentModel.DataAnnotations.Schema;

namespace Day2.Models
{
    public class CourseResult
    {
        public int Id { get; set; }
        public int Degree { get; set; }

        [ForeignKey("Course")]
        public int Course_Id { get; set; }

        [ForeignKey("Trainee")]
        public int Trianee_Id { get; set; }

        public Course Course { get; set; }
        public Trainee Trainee { get; set; }

    }
}
