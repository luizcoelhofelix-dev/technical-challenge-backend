using Books.Domain.Entities;
using Books.Domain.Interfaces;

namespace Books.Domain.Services
{
    public class BookService : IBookService
    {
        public Book? Add(Book newRecord, Author author, Genre genre)
        {
            if (!newRecord.IsValid())
                return null;

            if(author == null || genre == null)
                return null;

            return newRecord;
        }

        public Book? Update(Book registered, Book updated, Author author, Genre genre)
        {
            if (registered is null)
                return null; 

            if (!updated.IsValid())
                return null;
            
            if (author == null || genre == null)
                return null;

            registered.Update(updated);
            return registered;
        }
    }
}
