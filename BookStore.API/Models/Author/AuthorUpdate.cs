using System;
using System.Text.Json.Serialization;

namespace BookStore.API.Models.Author
{
    public class AuthorUpdate : BaseDto
    {
        [JsonPropertyName("first-name")]
        public String FirstName { get; set; }
        [JsonPropertyName("last-name")]
        public String LastName { get; set; }
        [JsonPropertyName("bio")]
        public String Bio { get; set; }
    }
}

