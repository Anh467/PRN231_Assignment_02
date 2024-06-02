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
    public class BookRepository : IGenericRepositorySingle<Book>
    {
        public void Add(Book entity)
        {
            BookDAO.Instance.Add(entity);   
        }

        public IEnumerable<Book> Find(Expression<Func<Book, bool>> expression)
        {
            return BookDAO.Instance.Find(expression);
        }

        public IEnumerable<Book> GetAll()
        {
            return BookDAO.Instance.GetAll();
        }

        public Book? GetById(int id)
        {
            return BookDAO.Instance.GetById(id);
        }

        public void Remove(int id)
        {
            BookDAO.Instance.Remove(id);
        }

        public void Update(Book entity)
        {
            BookDAO.Instance.Update(entity);
        }
    }
}
