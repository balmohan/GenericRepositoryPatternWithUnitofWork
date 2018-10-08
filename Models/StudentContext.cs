using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StudentMngmt.Models
{
    public class StudentContext:DbContext
    {
        public StudentContext():base("StudentENDemodb")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Books> Books { get; set; }
    }
}