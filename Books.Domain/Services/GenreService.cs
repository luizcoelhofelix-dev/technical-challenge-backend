using Books.Domain.Entities;
using Books.Domain.Interfaces;

namespace Books.Domain.Services
{
    public class GenreService : IGenreService
    {
        public Genre? Add(Genre newRecord)
        {
            if (newRecord.IsValid())
            {
                return newRecord;
            }

            return null;
        }

        public Genre? Update(Genre registered, Genre updated)
        {
            if (!updated.IsValid())
            {
                return null;
            }

            registered.Update(updated);

            return registered;
        }
    }
}
