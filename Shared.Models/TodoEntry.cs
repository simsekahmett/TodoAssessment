using System;
namespace Shared.Models
{
    public class TodoEntry
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DueDate { get; set; }
        public TaskStatus Status { get; set; }
    }
}

