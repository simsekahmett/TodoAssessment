using System;
using Shared.Models;

namespace DataAccess.Contracts
{
    public interface ITodoAssessmentRepository
    {
        public List<TodoEntry> GetAllTodoEntries();
        public List<TodoEntry> GetTodoEntriesByStatus(int status);
        public bool AddTodoEntry(TodoEntry entry);
        public bool UpdateTodoEntry(TodoEntry entry);
    }
}

