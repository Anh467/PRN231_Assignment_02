using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.interfaces
{
    public interface IDAO<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Update(T entity);
    }
    public interface IDAOSingle<T>
    {
        T? GetById(int id);
        void Remove(int id);
    }
    public interface IDAOBoth<T>
    {
        T? GetById(int id1, int id2);
        void Remove(int id1, int id2);
    }
}
