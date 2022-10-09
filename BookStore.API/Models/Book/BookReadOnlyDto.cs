using System;
using Newtonsoft.Json;

namespace BookStore.API.Models.Book
{
    public class BookReadOnlyDto : Author.BaseDto
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("author_id")]
        public int AuthorId { get; set; }

        [JsonProperty("author_name")]
        public int AuthorName { get; set; }

    }
}

