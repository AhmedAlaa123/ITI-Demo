namespace Day2.ViewModels
{

   
    public class TraineeViewModel
    {
        public int ID { get; set; }

        public string TraineeName { get; set; }
        public string Image { get; set; }
        public List<TraineeCourseViewModel> TraineeResults { get; set; }
    }
}
