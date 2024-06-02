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
    public class BookDAO : IDAOSingle<Book>
    {
        private static BookDAO instance = null;
        private static readonly object instanceLock = new object();
        private AppDBContext _context;
        private BookDAO()
        {
            this._context = new AppDBContext();
        }
        public static BookDAO Instance
        {
            get
            {
                lock (instanceLock)
                    if (instance == null)
                    {
                        instance = new BookDAO();
                    }
                return instance;
            }
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books;
        }

        public IEnumerable<Book> Find(Expression<Func<Book, bool>> expression)
        {
            return _context.Books.Where(expression);
        }

        public void Add(Book entity)
        {
            _context.Books.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Book entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges(); 
        }

        public Book? GetById(int id)
        {
            return _context.Books.SingleOrDefault(a=> a.BookId == id);
        }

        public void Remove(int id)
        {
            var book = GetById(id);
            if (book == null)
                throw new InvalidOperationException("Book cannot found");
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
