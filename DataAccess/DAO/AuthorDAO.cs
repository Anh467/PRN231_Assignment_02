using DataAccess.interfaces;
using Entity.Database;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class AuthorDAO : IDAO<Author>, IDAOSingle<Author>
    {
        private static AuthorDAO instance = null;
        private static readonly object instanceLock = new object();
        private AppDBContext _context;
        private AuthorDAO()
        {
            this._context = new AppDBContext();
        }
        public static AuthorDAO Instance
        {
            get
            {
                lock (instanceLock)
                    if (instance == null)
                    {
                        instance = new AuthorDAO();
                    }
                return instance;
            }
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors;
        }

        public IEnumerable<Author> Find(Expression<Func<Author, bool>> expression)
        {
            return _context.Authors.Where(expression);
        }

        public void Add(Author entity)
        {
            _context.Authors.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Author entity)
        {
            _context.Authors.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Author? GetById(int id)
        {
            return _context.Authors.SingleOrDefault(a=> a.AuthorID == id);
        }

        public void Remove(int id)
        {
            var author = GetById(id);
            if (author == null)
                throw new InvalidOperationException("Cannot find author");
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}
