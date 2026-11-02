using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Books.Application.Genre.Commands
{
    public class DeleteGenreCommand : IRequest<bool>
    {
        [Required]
        [JsonPropertyName("genre_code")]
        public int Code { get; set; }
    }
}
