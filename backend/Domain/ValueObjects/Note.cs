using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Note
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int CreatedByMemberId { get; set; }

        public Note() { }

        public Note(string content, int createdByMemberId)
        {
            Content = content;
            CreatedByMemberId = createdByMemberId;
        }

        public Note(int id, string content, DateTime createdAt, int createdByMemberId)
        {
            Id = id;
            Content = content;
            CreatedAt = createdAt;
            CreatedByMemberId = createdByMemberId;
        }
    }
}