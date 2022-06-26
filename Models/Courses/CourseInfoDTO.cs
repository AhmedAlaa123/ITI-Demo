using Day2.Models.Departments;

namespace Day2.Models.Courses
{
    public class CourseInfoDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }

        public DepartmentInfoDTO Department { get; set; }
    }
}
