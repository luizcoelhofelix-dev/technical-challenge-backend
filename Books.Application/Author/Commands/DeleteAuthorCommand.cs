using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Books.Application.Author.Commands
{
    public class DeleteAuthorCommand : IRequest<bool>
    {
        [JsonPropertyName("author_code")]
        public int Code { get; set; }
    }
}
