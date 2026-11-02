using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Books.Application.Book.Commands
{
    public class DeleteBookCommand : IRequest<bool>
    { 
        [Required]
        [JsonPropertyName("book_code")]
        public int Code { get; set; }
    }
}
