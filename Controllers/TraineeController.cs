using Microsoft.AspNetCore.Mvc;
using Day2.Models;
using Day2.ViewModels;
using Microsoft.EntityFrameworkCore;
namespace Day2.Controllers
{
    public class TraineeController : Controller
    {
       Context context=new Context();
      
        public IActionResult Index()
        {
            IEnumerable<Trainee> trainees = context.Trainees.Select(tra=>tra).Include(tra=>tra.Department);

            return View(trainees);
        }

        public IActionResult TraineeResult (int Id)
        {

            Trainee? trainee=context.Trainees.Include(tra => tra.courseResults).FirstOrDefault(train => train.Id == Id);
            
            if(trainee==null)
                return View("PageNotFound");

            TraineeViewModel traineeViewModel = new TraineeViewModel();
            traineeViewModel.TraineeName = trainee.Name;
            traineeViewModel.ID = trainee.Id;
            traineeViewModel.Image = trainee.Image;
            List<TraineeCourseViewModel> results=new List<TraineeCourseViewModel>();    

            foreach(CourseResult courseResult in trainee.courseResults)
            {
                Course? course = context.Courses.FirstOrDefault(crs => crs.Id == courseResult.Course_Id);

                if (course == null)
                    continue;

                results.Add(
                    new TraineeCourseViewModel()
                    {
                        CourseName = course.Name,
                        CourseDegree = courseResult.Degree,
                        color = (courseResult.Degree - course.MinDegree) < 0 ? "text-danger" : "text-success",
                        State = (courseResult.Degree - course.MinDegree) <0?State.Faild:State.Pass

                    });
            }

            traineeViewModel.TraineeResults = results;
            
            return View(traineeViewModel);
        }

        // this action to add new trainee

        public IActionResult AddNewTrainee()
        {
            return View(context.Departments.ToList());


        }

        [HttpPost]
        public IActionResult InsertTrainee(Trainee trainee, IFormFile Image)
        {

            if(trainee.Name==null|| trainee.Name.Trim()==String.Empty|| trainee.Address == null || trainee.Address.Trim() == String.Empty || Image == null)
            {
                ViewBag.Trainee = trainee;
                return RedirectToAction("AddNewTrainee", context.Departments.ToList());
            }

            // creating full path
            // Combine Fullpath with filename
            string fullPath = Path.Combine(Constants.TRAINEE_IMAGES_PATH, Image.FileName);
            // set Trainee image with image name
            trainee.Image = Image.FileName;

            // write image in wwwroot/image/Trainees
            Image.CopyTo(new FileStream(fullPath, FileMode.Create));
            // add Trainee in Trainees collection
            context.Trainees.Add(trainee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
