using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentMngmt.Models;
using StudentMngmt.Models.DTO;
using StudentMngmt.Repository;

namespace StudentMngmt.Controllers
{
    public class BookController : ApiController
    {
        UnitOfWork uw = new UnitOfWork(new StudentContext());
        public IQueryable<Books> GetBooks()
        {
            return uw.booksRepository.GetAll().AsQueryable<Books>();
        }
        public IHttpActionResult PostBooks(Books book)
        {
            if (ModelState.IsValid)
            {
                uw.booksRepository.Insert(book);
                uw.Complete();
                return Ok<Books>(book);
            }
            return BadRequest();
        }
        public IHttpActionResult GetBooks(int id)
        {
            return Ok<Books>(uw.booksRepository.Get(id));
        }
    }
}
