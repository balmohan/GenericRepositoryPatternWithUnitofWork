using StudentMngmt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StudentMngmt.Repository
{
    public class Repository<TENTITY> : IRepository<TENTITY> where TENTITY : class
    {
        protected StudentContext _context;
        public Repository(StudentContext dbcontext)
        {
            _context = dbcontext;
        }

        public void Delete(TENTITY Id)
        {
            _context.Set<TENTITY>().Remove(Id);
        }

        public IEnumerable<TENTITY> Find(Expression<Func<TENTITY, bool>> Predicate)
        {
            return _context.Set<TENTITY>().Where(Predicate);
        }
        public virtual TENTITY Get(int id)
        {
            return _context.Set<TENTITY>().Find(id);
        }

        public virtual IEnumerable<TENTITY> GetAll()
        {
            return _context.Set<TENTITY>().ToList();
        }

        public void Insert(TENTITY obj)
        {
            _context.Set<TENTITY>().Add(obj);
        }
    }
}