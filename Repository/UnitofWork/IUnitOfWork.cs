using StudentMngmt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMngmt.Repository
{
    public interface IUnitOfWork:IDisposable
    {
        Repository<Student> studentRepository { get; }
        Repository<Books> booksRepository { get; }
        int Complete();
    }
}
