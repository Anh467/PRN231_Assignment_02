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
    public class UserDAO: IDAOSingle<User>
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
            return _context.Users;
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> expression)
        {
            return _context.Users.Where(expression);
        }

        public void Add(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Update(User entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public User? GetById(int id)
        {
            return _context.Users.SingleOrDefault(a=> a.UserId == id);  
        }

        public void Remove(int id)
        {
            var user = GetById(id);
            if (user == null)
                throw new InvalidOperationException("User cannot find");
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
