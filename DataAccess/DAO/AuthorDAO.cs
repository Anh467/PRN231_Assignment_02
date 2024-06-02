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

        public void AddAsync(Author entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Author> FindAsync(Expression<Func<Author, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Author> GetAll()
        {
            throw new NotImplementedException();
        }

        public Author? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Author entity)
        {
            throw new NotImplementedException();
        }
    }
}
