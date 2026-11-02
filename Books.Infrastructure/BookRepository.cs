using Books.Domain.Entities;
using Books.Infrastructure.DBContext;
using Books.Infrastructure.Interfaces;

namespace Books.Infrastructure
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(BooksDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
