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
    public class RoleDAO: IDAOSingle<Role>
    {
        private static RoleDAO instance = null;
        private static readonly object instanceLock = new object();
        private AppDBContext _context;
        private RoleDAO()
        {
            this._context = new AppDBContext();
        }
        public static RoleDAO Instance
        {
            get
            {
                lock (instanceLock)
                    if (instance == null)
                    {
                        instance = new RoleDAO();
                    }
                return instance;
            }
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Roles;
        }

        public IEnumerable<Role> Find(Expression<Func<Role, bool>> expression)
        {
            return _context.Roles.Where(expression);
        }

        public void Add(Role entity)
        {
            _context.Roles.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Role entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public Role? GetById(int id)
        {
            return _context.Roles.SingleOrDefault(a=> a.RoleId == id);
        }

        public void Remove(int id)
        {
            var role = GetById(id);
            if (role == null)
                throw new InvalidOperationException("Role cannot find");
            _context.Remove(role);
            _context.SaveChanges();
        }
    }
}
