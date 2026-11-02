using Books.Infrastructure.DBContext;
using Books.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Books.Infrastructure
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public BooksDbContext _context;

        public RepositoryBase(BooksDbContext context)
        {
            _context = context;
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public virtual void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
                return _context.Set<T>().FirstOrDefaultAsync(predicate);

            return _context.Set<T>().FirstOrDefaultAsync();
        }

        public virtual IQueryable<T> Where(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
                return _context.Set<T>().Where(predicate);

            return _context.Set<T>().AsQueryable();
        }

        public virtual IQueryable<T> Query()
        {
            return _context.Set<T>().AsQueryable();
        }

        public virtual IQueryable<T> QueryAsNoTracking()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public virtual Task<List<T>> All()
        {
            return _context.Set<T>().ToListAsync();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
