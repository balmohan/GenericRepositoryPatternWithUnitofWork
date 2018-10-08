using StudentMngmt.Models;
using StudentMngmt.Models.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentMngmt.Repository
{
    public class BookRepository:Repository<Books>,IBooksRepository
    {
        public BookRepository(StudentContext context):base(context)
        {

        }
        public override Books Get(int id)
        {
            return base._context.Set<Books>().Include("Student").Where(b=>b.Id==id).FirstOrDefault<Books>();
        }
    }
}