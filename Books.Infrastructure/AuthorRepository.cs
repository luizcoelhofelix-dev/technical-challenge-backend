using Books.Domain.Entities;
using Books.Infrastructure.DBContext;
using Books.Infrastructure.Interfaces;

namespace Books.Infrastructure
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository 
    {
        public AuthorRepository(BooksDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
