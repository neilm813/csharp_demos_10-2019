using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumDemo.Models
{
    public class Post
    {
        [Key] // Primary Key
        public int PostId { get; set; }

        // Foreign Key 
        public int UserId { get; set; }
        
        // Navigation property for the relationship
        public User Author {get; set; } // 1 user related to each Post
        public List<Vote> Votes { get; set; } // 1 Post : M votes relationship


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