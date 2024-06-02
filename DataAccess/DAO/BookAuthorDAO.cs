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
    public class BookAuthorDAO : IDAO<BookAuthor>, IDAOBoth<Author>
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
            throw new NotImplementedException();
        }

        public IEnumerable<BookAuthor> FindAsync(Expression<Func<BookAuthor, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void AddAsync(BookAuthor entity)
        {
            throw new NotImplementedException();
        }

        public void Update(BookAuthor entity)
        {
            throw new NotImplementedException();
        }

        public Author? GetById(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id1, int id2)
        {
            throw new NotImplementedException();
        }
    }
}
