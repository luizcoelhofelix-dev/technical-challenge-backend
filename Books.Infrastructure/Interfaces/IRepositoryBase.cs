using System.Linq.Expressions;

namespace Books.Infrastructure.Interfaces;

public interface IRepositoryBase<T> where T : class
{
    void Add(T entity);

    void Update(T entity);

    void Remove(T entity);

    Task<T?> FirstOrDefaultAsync(
        Expression<Func<T, bool>>? predicate = null);

    IQueryable<T> Where(
        Expression<Func<T, bool>>? predicate = null);

    IQueryable<T> Query();

    IQueryable<T> QueryAsNoTracking();

    Task<List<T>> All();

    Task<int> SaveChangesAsync();
}