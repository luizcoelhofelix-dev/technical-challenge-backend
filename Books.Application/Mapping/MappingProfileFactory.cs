using Books.Application.Author.Commands;
using Books.Application.Author.DTOs;
using Books.Application.Book.Commands;
using Books.Application.Book.DTOs;
using Books.Application.Genre.Commands;
using Books.Application.Genre.DTOs;

namespace Books.Application.Mapping
{
    public static class MappingProfileFactory
    {
        public static AuthorDto MapToAuthorDto(Domain.Entities.Author author)
        {
            return new AuthorDto
            {
                Code = author.Id,
                Name = author.Name,
                DateOfBirth = author.DateOfBirth,
                Country = author.Country
            };
        }

        public static Domain.Entities.Author CreateMapToAuthor(CreateAuthorCommand author)
        {
            return new Domain.Entities.Author
            {
                Name = author.Name,
                DateOfBirth = author.DateOfBirth,
                Country = author.Country
            };
        }

        public static Domain.Entities.Author UpdateMapToAuthor(UpdateAuthorCommand author)
        {
            return new Domain.Entities.Author
            {
                Id = author.Code,
                Name = author.Name,
                DateOfBirth = author.DateOfBirth,
                Country = author.Country
            };
        }

        public static BookDto MapToBookDto(Domain.Entities.Book book)
        {
            return new BookDto
            {
                Code = book.Id,
                Title = book.Title,
                AuthorCode = book.AuthorId,
                GenreCode = book.GenreId,
                PublishedDate = book.PublishedDate,
                Description = book.Description,
                Price = book.Price
            };
        }

        public static Domain.Entities.Book CreateMapToBook(CreateBookCommand book)
        {
            return new Domain.Entities.Book
            {
                Title = book.Title,
                AuthorId = book.AuthorId,
                GenreId = book.GenreId,
                PublishedDate = book.PublishedDate,
                Description = book.Description,
                Price = book.Price
            };
        }

        public static Domain.Entities.Book UpdateMapToBook(UpdateBookCommand book)
        {
            return new Domain.Entities.Book
            {
                Id = book.Code,
                Title = book.Title,
                AuthorId = book.AuthorId,
                GenreId = book.GenreId,
                PublishedDate = book.PublishedDate,
                Description = book.Description,
                Price = book.Price
            };
        }

        public static GenreDto MapToGenreDto(Domain.Entities.Genre genre)
        {
            return new GenreDto
            {
                Code = genre.Id,
                Name = genre.Name
            };
        }

        public static Domain.Entities.Genre CreateMapToGenre(CreateGenreCommand genre)
        {
            return new Domain.Entities.Genre
            {
                Name = genre.Name
            };
        }

        public static Domain.Entities.Genre UpdateMapToGenre(UpdateGenreCommand genre)
        {
            return new Domain.Entities.Genre
            {
                Id = genre.Code,
                Name = genre.Name
            };
        }
    }
}