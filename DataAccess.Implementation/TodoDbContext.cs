using System;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace DataAccess.Implementation
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {

        }

        public DbSet<TodoEntry> Entries { get; set; }
    }
}

