using Books.Application.Book.DTOs;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Books.Application.Book.Commands
{
    public class UpdateBookCommand : IRequest<BookDto>
    {
        [Required]
        [JsonPropertyName("book_code")]
        public int Code { get; set; }
        [Required]
        [JsonPropertyName("book_title")]
        public string Title { get; set; }
        [Required]
        [JsonPropertyName("book_authorCode")]
        public int AuthorId { get; set; }
        [Required]
        [JsonPropertyName("book_genreCode")]
        public int GenreId { get; set; }
        [JsonPropertyName("book_publishDate")]
        public DateTime? PublishedDate { get; set; }
        [JsonPropertyName("book_price")]
        public decimal? Price { get; set; }
        [JsonPropertyName("book_description")]
        public string? Description { get; set; }
    }
}
