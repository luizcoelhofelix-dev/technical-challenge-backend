using Books.Application.Author.DTOs;
using Books.Application.Book.DTOs;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Books.Application.Author.Commands
{
    public class CreateAuthorCommand : IRequest<AuthorDto>
    {
        [Required]
        [JsonPropertyName("author_name")]
        public string Name { get; set; }
        [Required]
        [JsonPropertyName("author_dateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [JsonPropertyName("author_country")]
        public string Country { get; set; }
    }
}
