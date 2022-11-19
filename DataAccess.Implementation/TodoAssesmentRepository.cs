using System;
using DataAccess.Contracts;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using TaskStatus = Shared.Models.TaskStatus;

namespace DataAccess.Implementation
{
	public class TodoAssesmentRepository : ITodoAssessmentRepository
	{
		public TodoAssesmentRepository()
		{
            using (var context = new TodoDbContext())
            {
                if (context.Entries.ToList().Count == 0)
                {
                    context.Entries.AddRange(GenerateRandomEntries());
                    context.SaveChanges();
                }
            }
        }

        public List<TodoEntry> GetAllTodoEntries()
        {
            using (var context = new TodoDbContext())
            {
                return context.Entries.ToList();
            }
        }

        public bool AddTodoEntry(TodoEntry todoEntry)
        {
            try
            {
                using (var context = new TodoDbContext())
                {
                    context.Entries.Add(todoEntry);
                    context.SaveChanges();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateTodoEntry(TodoEntry updatedEntry)
        {
            try
            {
                using (var context = new TodoDbContext())
                {
                    var entryToBeUpdated = context.Entries.First(e => e.Id == updatedEntry.Id);

                    entryToBeUpdated.Title = updatedEntry.Title;
                    entryToBeUpdated.DueDate = updatedEntry.DueDate;
                    entryToBeUpdated.Status = updatedEntry.Status;

                    context.SaveChanges();

                    return true;
                }
            }
            catch
            {
                throw;
            }
        }

        private List<TodoEntry> GenerateRandomEntries()
        {
            List<TodoEntry> entryList = new List<TodoEntry>();
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                var status = TaskStatus.Pending;
                switch (i % 3)
                {
                    case 0:
                        status = TaskStatus.Pending;
                        break;

                    case 1:
                        status = TaskStatus.Overdue;
                        break;

                    case 2:
                        status = TaskStatus.Done;
                        break;
                }

                entryList.Add(new TodoEntry()
                {
                    Id = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(random.Next(3, 8)),
                    Status = status,
                    Title = "test title " + i
                });
            }

            return entryList;
        }
    }
}

