using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class Note
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int CreatedByMemberId { get; set; }

        public Note() { }

        public Note(string content, int createdByMemberId, DateTime? createdAt = null)
        {
            Content = content;
            CreatedByMemberId = createdByMemberId;
            CreatedAt = createdAt ?? DateTime.UtcNow;

        }
    }
}