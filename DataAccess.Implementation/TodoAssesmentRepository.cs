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
            try
            {
                using (var context = new TodoDbContext())
                {
                    return context.Entries.ToList();
                }
            }
            catch
            {
                return new List<TodoEntry>();
            }
        }

        public List<TodoEntry> GetTodoEntriesByStatus(int status)
        {
            try
            {
                using (var context = new TodoDbContext())
                {
                    return context.Entries.Where(e => (int)e.Status == status).ToList();
                }
            }
            catch
            {
                return new List<TodoEntry>();
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
                return false;
            }
        }

        private List<TodoEntry> GenerateRandomEntries()
        {
            List<TodoEntry> entryList = new List<TodoEntry>();
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                var status = TaskStatus.Pending;
                var dueDate = DateTime.Now;
                var createDate = DateTime.Now;
                switch (i % 3)
                {
                    case 0:
                        status = TaskStatus.Pending;
                        dueDate = DateTime.Now.AddDays(random.Next(3, 8));
                        break;

                    case 1:
                        status = TaskStatus.Overdue;
                        createDate = DateTime.Now.AddDays(-10);
                        dueDate = DateTime.Now.AddDays(-1);
                        break;

                    case 2:
                        status = TaskStatus.Done;
                        createDate = DateTime.Now.AddDays(-10);
                        dueDate = DateTime.Now.AddDays(-1);
                        break;
                }

                entryList.Add(new TodoEntry()
                {
                    Id = Guid.NewGuid(),
                    CreateDate = createDate,
                    DueDate = dueDate,
                    Status = status,
                    Title = "test title " + i
                });
            }

            return entryList;
        }
    }
}

