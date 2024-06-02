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
    public class PublisherRepository : IGenericRepository<Publisher>, IGenericRepositorySingle<Publisher>
    {
        public void Add(Publisher entity)
        {
            PublisherDAO.Instance.Add(entity);
        }

        public IEnumerable<Publisher> Find(Expression<Func<Publisher, bool>> expression)
        {
            return PublisherDAO.Instance.Find(expression);  
        }

        public IEnumerable<Publisher> GetAll()
        {
            return PublisherDAO.Instance.GetAll();
        }

        public Publisher? GetById(int id)
        {
            return PublisherDAO.Instance.GetById(id);
        }

        public void Remove(int id)
        {
            PublisherDAO.Instance.Remove(id);   
        }

        public void Update(Publisher entity)
        {
            PublisherDAO.Instance.Update(entity);
        }
    }
}
