using Books.Domain.Entities;

namespace Books.Domain.Interfaces
{
    public interface IAuthorService
    {
        public Author? Add(Author newRecord);
        public Author? Update(Author registered, Author updated);
    }
}
