using Books.Domain.Entities;

namespace Books.Domain.Interfaces
{
    public interface IGenreService
    {
        public Genre? Add(Genre newRecord);
        public Genre? Update(Genre registered, Genre updated);
    }
}
