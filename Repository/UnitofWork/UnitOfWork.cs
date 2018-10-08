using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentMngmt.Models;

namespace StudentMngmt.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentContext studentContext;
        public UnitOfWork(StudentContext context)
        {
            studentContext = context;
            studentRepository = new StudentRepository(studentContext);
            booksRepository = new BookRepository(studentContext);

        }
        public Repository<Student> studentRepository { get; private set; }
        public Repository<Books> booksRepository { get; private set; }
        public int Complete()
        {
            var result = -1;
            try
            {
                result= studentContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                Dispose();
            }
            return result;
        }
        public void Dispose()
        {
            studentContext.Dispose();
        }
    }
}