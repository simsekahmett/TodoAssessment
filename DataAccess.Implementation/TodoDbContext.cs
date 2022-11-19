using System;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace DataAccess.Implementation
{
    public class TodoDbContext : DbContext
    {
        public DbSet<TodoEntry> Entries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TodoAssessmentDb");
        }
    }
}

