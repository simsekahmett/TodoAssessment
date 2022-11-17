using System;
namespace DataAccess.Models
{
	public class TodoEntry
	{
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}

