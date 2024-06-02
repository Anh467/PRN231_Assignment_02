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
    public class AuthorRepository : IGenericRepository<Author>, IGenericRepositorySingle<Author>
    {
        public void Add(Author entity)
        {
            AuthorDAO.Instance.Add(entity);
        }

        public IEnumerable<Author> Find(Expression<Func<Author, bool>> expression)
        {
            return AuthorDAO.Instance.Find(expression);
        }

        public IEnumerable<Author> GetAll()
        {
            return AuthorDAO.Instance.GetAll();
        }

        public Author? GetById(int id)
        {
            return AuthorDAO.Instance.GetById(id);
        }

        public void Remove(int id)
        {
            AuthorDAO.Instance.Remove(id);  
        }

        public void Update(Author entity)
        {
            AuthorDAO.Instance.Update(entity);
        }
    }
}
