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
    public class UserDAO: IDAO<User>, IDAOSingle<User>
    {
        private static UserDAO instance = null;
        private static readonly object instanceLock = new object();
        private AppDBContext _context;
        private UserDAO()
        {
            this._context = new AppDBContext();
        }
        public static UserDAO Instance
        {
            get
            {
                lock (instanceLock)
                    if (instance == null)
                    {
                        instance = new UserDAO();
                    }
                return instance;
            }
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public User? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
