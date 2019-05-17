using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Laborator2.Models.Data
{
    public class TasksDbContext : DbContext
    {
        public TasksDbContext(DbContextOptions<TasksDbContext> options) : base(options)
        {
        }

        // DbSet = Repository
        // DbSet = O tabela din baza de date
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
