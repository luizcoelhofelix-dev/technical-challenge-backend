using Books.Application.Genre.DTOs;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Books.Application.Genre.Commands
{
    public class CreateGenreCommand : IRequest<GenreDto>
    {
        [Required]
        [JsonPropertyName("genre_description")]
        public string Name { get; set; }
    }
}
