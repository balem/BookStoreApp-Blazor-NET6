using System;
using System.ComponentModel.DataAnnotations;
using BookStore.API.Models.Author;
using Newtonsoft.Json;

namespace BookStore.API.Models.Book
{
    public class BookCreateDto : BaseDto 
    {
        [Required]
        [StringLength(50)]
        [JsonProperty("title")]
        public string Title { get; set; }

        [Required]
        [JsonProperty("year")]
        [Range(1000, int.MaxValue)]
        public string Year { get; set; }

        [Required]
        [JsonProperty("isbn")]
        public string Isbn { get; set; }

        [Required]
        [StringLength(250, MinimumLength =10)]
        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}

