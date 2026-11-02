using Books.Application.Genre.DTOs;
using MediatR;
using System.Text.Json.Serialization;

namespace Books.Application.Genre.Queries
{
    public class GenreComplexFilter : IRequest<IEnumerable<GenreDto>>
    {
        [JsonPropertyName("genre_code")]
        public int? Code { get; set; }
        [JsonPropertyName("genre_description")]
        public string? Description { get; set; }
    }
}
