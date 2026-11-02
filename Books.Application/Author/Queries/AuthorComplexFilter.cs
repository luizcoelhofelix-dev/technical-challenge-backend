using Books.Application.Author.DTOs;
using MediatR;
using System.Text.Json.Serialization;

namespace Books.Application.Author.Queries
{
    public class AuthorComplexFilter : IRequest<IEnumerable<AuthorDto>>
    {
        [JsonPropertyName("author_code")]
        public int? Code { get; set; }
        [JsonPropertyName("author_name")]
        public string? Name { get; set; }
        [JsonPropertyName("author_country")]
        public string? Country { get; set; }
    }
}
