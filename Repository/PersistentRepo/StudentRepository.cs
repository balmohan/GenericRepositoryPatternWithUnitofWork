using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentMngmt.Models;
using System.Data.Entity;
using System.Linq.Expressions;

namespace StudentMngmt.Repository
{
    public class StudentRepository : Repository<Student>,IStudentRepository
    {

        public StudentRepository(StudentContext context):base(context)
        {
           

        }
        public override Student Get(int id)
        {
            var student = (from s in base._context.Set<Student>().Include("books")
                           where s.id == id
                           select s
                         ).FirstOrDefault();
            var st = _context.Set<Student>().Include("books").Where(s => s.id == id).FirstOrDefault<Student>();
            return st;
        }

    }
}