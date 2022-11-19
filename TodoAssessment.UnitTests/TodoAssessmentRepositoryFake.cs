using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contracts;
using Shared.Models;
using TaskStatus = Shared.Models.TaskStatus;

namespace TodoAssessment.UnitTests
{
    public class TodoAssessmentRepositoryFake : ITodoAssessmentRepository
    {
        private readonly List<TodoEntry> todoEntries;
        public TodoAssessmentRepositoryFake()
        {
            todoEntries = new List<TodoEntry>()
            {
                new TodoEntry()
                {
                    Id = new Guid("ab1bd817-98cd-4cf3-a80a-53ea0cd9c201"),
                    Title = "Test Todo Item Title [pending]",
                    CreateDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(10),
                    Status = TaskStatus.Pending
                },
                new TodoEntry()
                {
                    Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c202"),
                    Title = "Test Todo Item Title 2 [done]",
                    CreateDate = DateTime.Now,
                    DueDate = DateTime.Now,
                    Status = TaskStatus.Done
                },
                new TodoEntry()
                {
                    Id = new Guid("ab3bd817-98cd-4cf3-a80a-53ea0cd9c203"),
                    Title = "Test Todo Item Title 3 [overdue]",
                    CreateDate = DateTime.Now.AddDays(-3),
                    DueDate = DateTime.Now,
                    Status = TaskStatus.Overdue
                },

            };
        }

        public List<TodoEntry> GetAllTodoEntries()
        {
            return todoEntries;
        }

        public bool AddTodoEntry(TodoEntry entry)
        {
            todoEntries.Add(entry);
            return true;
        }

        public bool UpdateTodoEntry(TodoEntry entry)
        {
            var existingEntry = todoEntries.Find(e => e.Id == entry.Id);
            if (existingEntry != null)
            {
                existingEntry.Title = entry.Title;
                existingEntry.DueDate = entry.DueDate;
                existingEntry.Status = entry.Status;

                return true;
            }
            else
                return false;
        }
    }
}
