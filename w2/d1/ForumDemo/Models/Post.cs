using System;
using System.ComponentModel.DataAnnotations;

namespace ForumDemo.Models
{
    public class Post
    {
        
        [Required]
        [MinLength(2, ErrorMessage = "Must be more than 2 characters.")]
        public string Username { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Must be more than 2 characters.")]
        public string Topic { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Must be more than 2 characters.")]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}