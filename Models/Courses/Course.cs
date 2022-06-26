using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace Day2.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Degree { get; set; }
        public int MinDegree { get; set; }

        [ForeignKey("Department")]
        public int Dept_Id { get; set; }

        public Department Department { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
        public ICollection<CourseResult> CourseResults { get; set; }

      

    }


    //class person
    //{
    //    public string Name { get; set; }
    //    public int age { get; set; }

    //    public string Address { get; set; }

    //    public override string ToString()
    //    {
    //        return $"Name {this.Name} Age : {this.age} Address {this.Address}";
    //    }
    //}

    //class Teacher : person
    //{
    //    public string Jop { get; set; }
    //    public int Salary { get; set; }
    //    public override string ToString()
    //    {
    //        return base.ToString() + " Jop " + this.Jop + "Salary : " + this.Salary;
    //    }
    //}

    //class Student : person
    //{
    //    public string Level { get; set; }

    //    public override string ToString()
    //    {
    //        return base.ToString() + " Level " + this.Level;
    //    }

    //}

    //class ItI
    //{
    //    public List<person> Persons { get; set; }


    //    public void Display()
    //    {
    //        foreach (person per in this.Persons)

    //        {
    //            Console.WriteLine(per);
    //        }
    //    }
    //}

    //public class Test
    //{
    //    public static void Main()
    //    {
    //        ItI iti = new ItI();
    //        iti.Persons.Add(new Student() { Name = "Ahmed", age = 24, Level = "third", Address = "aaaaa" });
    //        iti.Persons.Add(new Teacher() { Name = "Ahmed", age = 24, Jop = "jop1", Address = "aaaaa" });
    //           iti.Persons.Add(new Student() { Name = "Ahmed", age = 24, Level = "third", Address = "aaaaa" });
    //          iti.Persons.Add(new Teacher() { Name = "Ahmed", age = 24, Jop = "jop1", Address = "aaaaa" });
    //           iti.Persons.Add(new Student() { Name = "Ahmed", age = 24, Level = "third", Address = "aaaaa" });
    //            iti.Persons.Add(new Teacher() { Name = "Ahmed", age = 24, Jop = "jop1", Address = "aaaaa" });

    //        iti.Display();


    //}
    //}
}
