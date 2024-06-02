using DataAccess.interfaces;
using Entity.Database;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class BookDAO : IDAO<Book>, IDAOSingle<Book>
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
            throw new NotImplementedException();
        }

        public IEnumerable<Book> FindAsync(Expression<Func<Book, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void AddAsync(Book entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Book entity)
        {
            throw new NotImplementedException();
        }

        public Book? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
