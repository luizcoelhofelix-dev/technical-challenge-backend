using System.Text.Json.Serialization;

namespace Books.Application.Book.DTOs
{
    public class BookDto
    {
        [JsonPropertyName("book_code")]
        public int Code { get; set; }
        [JsonPropertyName("book_title")]
        public string Title { get; set; }
        [JsonPropertyName("book_authorCode")]
        public int AuthorCode { get; set; }
        [JsonPropertyName("book_genreCode")]
        public int GenreCode { get; set; }
        [JsonPropertyName("book_publishDate")]
        public DateTime? PublishedDate { get; set; }
        [JsonPropertyName("book_price")]
        public decimal? Price { get; set; }
        [JsonPropertyName("book_description")]
        public string? Description { get; set; }
    }
}
