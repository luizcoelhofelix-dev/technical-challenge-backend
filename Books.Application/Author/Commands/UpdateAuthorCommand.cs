using Books.Application.Author.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Books.Application.Author.Commands
{
    public class UpdateAuthorCommand : IRequest<AuthorDto>
    {
        [Required]
        [JsonPropertyName("author_code")]
        public int Code { get; set; }
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
