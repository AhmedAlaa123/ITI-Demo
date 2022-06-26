﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Day2.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Image { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }

        [ForeignKey("Department")]
        public int Dept_Id { get; set; }

        [ForeignKey("Course")]
        public int Course_Id { get; set; }

        public Department Department { get; set; }

        public Course Course { get; set; }
    }
}