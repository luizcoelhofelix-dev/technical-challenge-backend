using Books.Domain.Entities;

namespace Books.Domain.Interfaces
{
    public interface IBookService
    {
        public Book? Add(Book newRecord, Author author, Genre genre);
        public Book? Update(Book registered, Book updated, Author author, Genre genre);
    }
}
