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
    /// <summary>
    /// Using for entity which has a single field is primary
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDAOSingle<T> : IDAO<T>
    {
        T? GetById(int id);
        void Remove(int id);
    }
    /// <summary>
    /// Using for entity which has two fields are primary
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDAOBoth<T> : IDAO<T>
    {
        T? GetById(int id1, int id2);
        void Remove(int id1, int id2);
    }
}
