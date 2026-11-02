using Books.Domain.Entities;
using Books.Domain.Interfaces;

namespace Books.Domain.Services
{
    public class AuthorService : IAuthorService
    {
        public Author? Add(Author newRecord)
        {
            if (newRecord.IsValid())
            {
                return newRecord;
            }

            return null;
        }

        public Author? Update(Author registered, Author updated) {
            if (!updated.IsValid())
            {
                return null;
            }

            registered.Update(updated);

            return registered;
        }
    }
}
