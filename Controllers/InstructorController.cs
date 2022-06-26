using Microsoft.AspNetCore.Mvc;
using Day2.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Day2.Models.Instructors;
using AutoMapper;

namespace Day2.Controllers
{
    public class InstructorController : Controller
    {
        Context context=new Context();
        private readonly IMapper _mapper;

        public InstructorController( IMapper mapper)
        {
            _mapper = mapper;
        }
        public IActionResult Index()
        {

            return View("Index",context.Instructors.ToList());
        }

        public IActionResult InstructorDetails(int id)
        {

            Instructor? instructor = context.Instructors.Include(i=>i.Department).Include(i=>i.Course).FirstOrDefault(inst =>inst.Id == id);

            if(instructor==null)
            {
                return View("PageNotFound");
            }
            else
            {
                return View("InstructorDetails",instructor);
            }
           

        }

        public IActionResult AddNewInstructor()
        {

            ViewBag.Departments = context.Departments.ToList();
            ViewBag.Courses = context.Courses.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult InsertInstructor(InstructorCreateDTO inst )
        {


            //Instructor instructor = new Instructor();

            if (inst.Name == null || inst.Name.Trim() == String.Empty || inst.Address == null || inst.Address.Trim() == string.Empty || inst.ImageFile == null)
            {
                ViewBag.Departments = context.Departments.ToList();
                ViewBag.Courses = context.Courses.ToList();
                return View("AddNewInstructor", inst);
            }

            string fullPath = Path.Combine(Constants.INSTRUCTORS_IMAGES_PATH, inst.ImageFile.FileName);
            // set instructor image with image name
            //inst.Image = inst.Image.FileName; 

            // write image in wwwroot/image/instructors
            inst.ImageFile.CopyTo(new FileStream(fullPath, FileMode.Create));
            inst.Image = inst.ImageFile.FileName;
           
            var instructor = _mapper.Map<InstructorCreateDTO, Instructor>(inst);
            context.Instructors.Add(instructor);
            // save instructor  in database
            context.SaveChanges();
            // back to index view
            return View("Index", context.Instructors.ToList());

        }

      
        public IActionResult UpdateInstructor(int id)
        {
         
            Instructor? instructor = context.Instructors.ToList().FirstOrDefault(inst => inst.Id == id);
            if(instructor==null)
                return View("PageNotFound");



            ViewBag.Departments = context.Departments.ToList();
            ViewBag.Courses = context.Courses.ToList();
            return View(instructor);
        }

        [HttpPost]
        public IActionResult UpdateInstructoreData(Instructor inst)
        {

            ViewBag.Departments = context.Departments.ToList();
            ViewBag.Courses = context.Courses.ToList();

            if (inst.Name == null || inst.Name.Trim() == String.Empty || inst.Address == null || inst.Address.Trim() == string.Empty || inst.Image == null || inst.Image.Trim() == string.Empty)
            {
              
                return View("UpdateInstructor", inst);
            }
          
            Instructor? instructor = context.Instructors.FirstOrDefault(ins => ins.Id == inst.Id);

            // redirect to page not found if instructor is not found
            if (instructor == null)
                return View("PageNotFound");


            // update Instructor

            instructor.Name = inst.Name;
            instructor.Salary = inst.Salary;
            instructor.Address = inst.Address;
            instructor.Image = inst.Image;
            instructor.Dept_Id = inst.Dept_Id;
            instructor.Course_Id = inst.Course_Id;
            context.SaveChanges();
            return View("Index", context.Instructors.ToList());
        }


    }
}
