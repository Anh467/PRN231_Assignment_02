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
    public class BookAuthorRepository : IGenericRepository<BookAuthor>, IGenericRepositoryBoth<BookAuthor>
    {
        public void Add(BookAuthor entity)
        {
            BookAuthorDAO.Instance.Add(entity);
        }

        public IEnumerable<BookAuthor> Find(Expression<Func<BookAuthor, bool>> expression)
        {
            return BookAuthorDAO.Instance.Find(expression);
        }

        public IEnumerable<BookAuthor> GetAll()
        {
            return BookAuthorDAO.Instance.GetAll();
        }

        public BookAuthor? GetById(int id1, int id2)
        {
            return BookAuthorDAO.Instance.GetById(id1, id2);
        }

        public void Remove(int id, int id2)
        {
            BookAuthorDAO.Instance.Remove(id, id2);
        }

        public void Update(BookAuthor entity)
        {
            BookAuthorDAO.Instance.Update(entity);  
        }
    }
}
