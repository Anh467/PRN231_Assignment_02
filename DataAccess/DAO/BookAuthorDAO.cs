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
    public class BookAuthorDAO :  IDAOBoth<BookAuthor>
    {
        private static BookAuthorDAO instance = null;
        private static readonly object instanceLock = new object();
        private AppDBContext _context;
        private BookAuthorDAO()
        {
            this._context = new AppDBContext();
        }
        public static BookAuthorDAO Instance
        {
            get
            {
                lock (instanceLock)
                    if (instance == null)
                    {
                        instance = new BookAuthorDAO();
                    }
                return instance;
            }
        }

        public IEnumerable<BookAuthor> GetAll()
        {
            return _context.BookAuthors;
        }

        public IEnumerable<BookAuthor> Find(Expression<Func<BookAuthor, bool>> expression)
        {
            return _context.BookAuthors.Where(expression);
        }

        public void Add(BookAuthor entity)
        {
            _context.BookAuthors.Add(entity);
            _context.SaveChanges();
        }

        public void Update(BookAuthor entity)
        {
            _context.BookAuthors.Attach(entity);    
            _context.Entry(entity).State  = EntityState.Modified;
            _context.SaveChanges();
        }

        public BookAuthor? GetById(int id1, int id2)
        {
            return _context.BookAuthors.SingleOrDefault(a => a.AuthorId == id1 && a.BookId == id2);
        }

        public void Remove(int id1, int id2)
        {
            var bookAuthor = GetById(id1, id2);
            if (bookAuthor == null)
                throw new InvalidOperationException("Cannot find bookAuthor");
            _context.Remove(bookAuthor);
            _context.SaveChanges();
        }
    }
}
