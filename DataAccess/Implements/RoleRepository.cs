using DataAccess.DAO;
using Entity.Models;
using QuanLyChiHoi.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implements
{
    public class RoleRepository : IGenericRepository<Role>, IGenericRepositorySingle<Role>
    {
        public void Add(Role entity)
        {
            RoleDAO.Instance.Add(entity);
        }

        public IEnumerable<Role> Find(Expression<Func<Role, bool>> expression)
        {
            return RoleDAO.Instance.Find(expression);   
        }

        public IEnumerable<Role> GetAll()
        {
            return RoleDAO.Instance.GetAll();
        }

        public Role? GetById(int id)
        {
            return RoleDAO.Instance.GetById(id);
        }

        public void Remove(int id)
        {
            RoleDAO.Instance.Remove(id);
        }

        public void Update(Role entity)
        {
            RoleDAO.Instance.Update(entity);
        }
    }
}
