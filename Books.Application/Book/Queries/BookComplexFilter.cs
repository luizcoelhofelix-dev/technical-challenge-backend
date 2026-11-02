using Books.Application.Book.DTOs;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Books.Application.Book.Queries
{
    public class BookComplexFilter : IRequest<IEnumerable<BookDto>>
    {
        [JsonPropertyName("book_code")]
        public int? Code { get; set; }
        [JsonPropertyName("book_description")]
        public string? Description { get; set; }
        [JsonPropertyName("book_authorCode")]
        public int? AuthorId { get; set; }
        [JsonPropertyName("book_genreCode")]
        public int? GenreId { get; set; }
        [JsonPropertyName("book_publishDate")]
        public DateTime? PublishedDate { get; set; }
    }
}
