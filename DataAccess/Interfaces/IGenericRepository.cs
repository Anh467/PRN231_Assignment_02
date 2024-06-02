using System.Linq.Expressions;

namespace QuanLyChiHoi.Repositories.Interface
{
    public interface IGenericRepository<T> where T : class
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
    public interface IGenericRepositorySingle<T> : IGenericRepository<T> where T : class 
    {
        T? GetById(int id);
        void Remove(int id);
    }
    /// <summary>
    /// Using for entity which has two fields are primary
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepositoryBoth<T> : IGenericRepository<T> where T : class
    {
        T? GetById(int id1, int id2);
        void Remove(int id, int id2);
    }
}
