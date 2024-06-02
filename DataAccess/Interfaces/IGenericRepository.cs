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

    public interface IGenericRepositorySingle<T> where T : class
    {
        T? GetById(int id);
        void Remove(int id);
    }
    public interface IGenericRepositoryBoth<T> where T : class
    {
        T? GetById(int id1, int id2);
        void Remove(int id, int id2);
    }
}
