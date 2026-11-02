using Books.Domain.Entities;
using Books.Infrastructure.DBContext;
using Books.Infrastructure.Interfaces;

namespace Books.Infrastructure
{
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public GenreRepository(BooksDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
