using System;
using System.ComponentModel.DataAnnotations;

namespace ForumDemo.Models
{
    public class Vote
    {
        [Key] // denotes PK, not needed if named ModelNameId
        public int VoteId { get; set; } // PK
        // FK
        public int PostId { get; set; }
        // FK
        public int UserId { get; set; }
        public bool IsUpvote { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        /* 
            Navigation properties
            Not stored in DB, just used
            by Entity Framework to be able
            to use .include to get the full
            info from related classes
        */
        public User Voter { get; set; }
        public Post Post { get; set; }
    }
}