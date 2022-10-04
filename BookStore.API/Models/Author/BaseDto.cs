using System;
using System.Text.Json.Serialization;

namespace BookStore.API.Models.Author
{
    public abstract class BaseDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}

