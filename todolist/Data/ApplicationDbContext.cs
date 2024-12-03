using Microsoft.EntityFrameworkCore;
using todolist.Models;

namespace todolist.Data;

public class ApplicationDbContext: DbContext
{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskItem> TaskItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Здесь вы можете настроить данные
            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem { Id = 1, Title = "Task 1", Status = "Pending" },
                new TaskItem { Id = 2, Title = "Task 2", Status = "Completed" }
            );
        }
}