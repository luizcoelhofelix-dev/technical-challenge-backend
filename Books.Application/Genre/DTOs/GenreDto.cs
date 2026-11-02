using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Books.Application.Genre.DTOs
{
    public class GenreDto
    {
        [JsonPropertyName("genre_code")]
        public int Code { get; set; }
        [JsonPropertyName("genre_description")]
        public string Name { get; set; }
    }
}
