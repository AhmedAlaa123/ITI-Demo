using Day2.Models;
using Day2.Models.Courses;
using Microsoft.AspNetCore.Mvc;
using Day2.Models.Departments;
using Microsoft.EntityFrameworkCore;

namespace Day2.Controllers
{
    public class CourseController : Controller
    {
        Context context = new Context();

        private List<CourseInfoDTO> GetCourseInfoDTOs()
        {
            List<Course> courses = context.Courses.Include(cr => cr.Department).ToList();
            List<CourseInfoDTO> courseInfoDTOs = new List<CourseInfoDTO>();
            foreach (Course course in courses)
            {
                courseInfoDTOs.Add(new CourseInfoDTO()
                {
                    Id=course.Id,
                    Name = course.Name,
                    Degree = course.Degree,
                    MinDegree = course.MinDegree,
                    Department = new DepartmentInfoDTO()
                    {
                        Name = course.Department.Name,
                        MangerName = course.Department.MangerName != null ? course.Department.MangerName : "Not Set Yet!"
                    }

                });
            }
            return courseInfoDTOs;
        }
        public IActionResult Index()
        {

          

            return View(GetCourseInfoDTOs());
            
        }

        private List<DepartmentInfoDTO> GetDepartmentInfoDTOs()
        {
            var Departments = context.Departments.ToList();
            List<DepartmentInfoDTO> departmentInfos = new List<DepartmentInfoDTO>();
            foreach (Department department in Departments)
            {
                departmentInfos.Add(new DepartmentInfoDTO
                {
                    Id = department.Id,
                    Name = department.Name

                });
            }
            return departmentInfos;
        }
        public IActionResult CreateCourse()
        {
            ViewData["Deparments"] = GetDepartmentInfoDTOs();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InsertCourse(CourseCreateDTO course )
        {
            if (!ModelState.IsValid)
            {
                ViewData["Deparments"] = GetDepartmentInfoDTOs();
                return View("CreateCourse", course);

            }
            if(course.Dept_Id==0)
            {
                ModelState.AddModelError("Dept_Id","*Select Department");
                ViewData["Deparments"] = GetDepartmentInfoDTOs();
                return View("CreateCourse", course);
            }
            Course courseTemp = new Course();
            courseTemp.Name = course.Name;
            courseTemp.MinDegree = course.MinDegree;
            courseTemp.Degree = course.Degree;
            courseTemp.Dept_Id = course.Dept_Id;

            context.Courses.Add(courseTemp);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ValidateDegree(int MinDegree, int Degree)
        {
            if (Degree < MinDegree)
                return Json(false);
            return Json(true);
        }

        public IActionResult UpdateCourse(int id)
        {
            Course course = context.Courses.Include(cr => cr.Department).ToList().FirstOrDefault(cr => cr.Id == id);

            if (course == null)
                return View("PageNotFound");

            CourseInfoDTO courseInfoDTO = new CourseInfoDTO
            {
                Name = course.Name,
                Id = course.Id,
                Degree = course.Degree,
                MinDegree = course.MinDegree,
                Dept_Id= course.Department.Id,
                Department = new DepartmentInfoDTO
                {
                    Id=course.Department.Id,
                    Name=course.Department.Name,
                    MangerName=course.Department.MangerName
                }
            };
            ViewData["Deparments"] = GetDepartmentInfoDTOs();
            return View("Update", courseInfoDTO);
        }

        public IActionResult Update(CourseInfoDTO courseInfoDTO)
        {
            
            if (!ModelState.IsValid)
            {
                ViewData["Deparments"] = GetDepartmentInfoDTOs();
               return  View("Update", courseInfoDTO);

            }

            if (courseInfoDTO.Dept_Id == 0)
            {
                ModelState.AddModelError("Dept_Id", "*Select Department");
                ViewData["Deparments"] = GetDepartmentInfoDTOs();
                return View("Update", courseInfoDTO);
            }

            Course course = context.Courses.Include(cr => cr.Department).FirstOrDefault(cr => cr.Id == courseInfoDTO.Id);

            if(course!=null)
            {
                course.Name = courseInfoDTO.Name;
                course.MinDegree = courseInfoDTO.MinDegree;
                course.Degree = courseInfoDTO.Degree;
                course.Dept_Id = courseInfoDTO.Dept_Id;
                context.SaveChanges();


            }

            return RedirectToAction("Index");
        }
    }
}
