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
    public class PublisherDAO : IDAO<Publisher>, IDAOSingle<Publisher>
    {
        private static PublisherDAO instance = null;
        private static readonly object instanceLock = new object();
        private AppDBContext _context;
        private PublisherDAO()
        {
            this._context = new AppDBContext();
        }
        public static PublisherDAO Instance
        {
            get
            {
                lock (instanceLock)
                    if (instance == null)
                    {
                        instance = new PublisherDAO();
                    }
                return instance;
            }
        }

        public IEnumerable<Publisher> GetAll()
        {
            return _context.Publishers;
        }

        public IEnumerable<Publisher> Find(Expression<Func<Publisher, bool>> expression)
        {
            return _context.Publishers.Where(expression);
        }

        public void Add(Publisher entity)
        {
            _context.Publishers.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Publisher entity)
        {
            _context.Publishers.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Publisher? GetById(int id)
        {
            return _context.Publishers.SingleOrDefault(a=> a.PubId == id);
        }

        public void Remove(int id)
        {
            var publisher = GetById(id);
            if (publisher == null)
                throw new InvalidOperationException("Publisher cannot find");
            _context.Publishers.Remove(publisher);
            _context.SaveChanges();
        }
    }
}
