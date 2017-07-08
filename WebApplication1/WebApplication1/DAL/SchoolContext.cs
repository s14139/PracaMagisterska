using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebApplication1.DAL
{
    public class SchoolContext 
    {

        public SchoolContext()
        {
            Students = new List<Student> { };
            Enrollments = new List<Enrollment> { };
            Courses = new List<Course> { };
            Difficulties = new List<Difficulty> { };
        }

        public List<Student> Students { get; set; }
        public List<Enrollment> Enrollments { get; set; }
        public List<Course> Courses { get; set; }
        public List<Difficulty> Difficulties { get; set; }
    }
}