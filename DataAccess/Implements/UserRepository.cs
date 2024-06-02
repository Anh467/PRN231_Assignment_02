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
    public class UserRepository : IGenericRepository<User>, IGenericRepositorySingle<User>
    {
        public void Add(User entity)
        {
            UserDAO.Instance.Add(entity);
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> expression)
        {
            return UserDAO.Instance.Find(expression);   
        }

        public IEnumerable<User> GetAll()
        {
            return UserDAO.Instance.GetAll();
        }

        public User? GetById(int id)
        {
            return UserDAO.Instance.GetById(id);
        }

        public void Remove(int id)
        {
            UserDAO.Instance.Remove(id);
        }

        public void Update(User entity)
        {
            UserDAO.Instance.Update(entity);
        }
    }
}
