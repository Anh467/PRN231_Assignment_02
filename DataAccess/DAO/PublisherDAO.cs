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
            throw new NotImplementedException();
        }

        public IEnumerable<Publisher> Find(Expression<Func<Publisher, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Add(Publisher entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Publisher entity)
        {
            throw new NotImplementedException();
        }

        public Publisher? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
