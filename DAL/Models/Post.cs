using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public User Author { get; set; }
        public string Theme { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int? Likes { get; set; }
        public string Img { get; set; }
    }
}
