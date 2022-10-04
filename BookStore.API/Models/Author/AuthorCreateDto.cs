using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Models.Author
{
    public class AuthorCreateDto
    {
        [Required]
        [StringLength(50)]
        public String FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public String LastName { get; set; }

        [StringLength(50)]
        public String bio { get; set; }


    }
}

