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
    public class RoleDAO: IDAO<Role>, IDAOSingle<Role>
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
            throw new NotImplementedException();
        }

        public IEnumerable<Role> FindAsync(Expression<Func<Role, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void AddAsync(Role entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Role entity)
        {
            throw new NotImplementedException();
        }

        public Role? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
