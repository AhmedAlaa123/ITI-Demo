namespace Day2.ViewModels
{
    public enum State
    {
        Pass,
        Faild
    }
    public class TraineeCourseViewModel
    {
        public string CourseName { get; set; }
        public int CourseDegree { get; set; }

        public string color { get; set; }
        public State State { get; set; }
    }
}
