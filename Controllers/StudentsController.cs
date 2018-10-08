using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.ModelBinding;
using System.Web.UI.WebControls;
using StudentMngmt.Models;
using StudentMngmt.Repository;

namespace StudentMngmt.Controllers
{
    public class StudentsController : ApiController
    {
        UnitOfWork uw = new UnitOfWork(new StudentContext());
        // GET: api/Students
        public IQueryable<Student> GetStudents()
        {
            return uw.studentRepository.GetAll().AsQueryable();
        }

        // GET: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(int id)
        {
            if(uw.studentRepository.Get(id) != null)
            {
                return Ok<Student>(uw.studentRepository.Get(id));
            }
            else
            {
                return NotFound();
            }
        }



        // POST: api/Students
        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudent(Student student)
        {
            
            var result = -1;
            if (ModelState.IsValid)
            {
                uw.studentRepository.Insert(student);
                result = uw.Complete();
            }
            if(result == 1)
            {
                return Ok<Student>(student);
            }
            return BadRequest(ModelState);

        }

        public IHttpActionResult PutStudent([FromUri]int id, Student student)
        {
            var result=uw.studentRepository.Get(id);
            result.studentName = student.studentName;
            result.studentAddress = student.studentAddress;
            result.studentAge = student.studentAge;
            
            uw.Complete();
     
            return Ok<Student>(result);
        }

        // DELETE: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {
            var student = uw.studentRepository.Get(id);
            uw.studentRepository.Delete(student);
            uw.Complete();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}