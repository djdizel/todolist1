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
 
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);
        //     modelBuilder.Entity<TaskItem>().HasData(
        //         new TaskItem { Id = 1, Title = "Sample Task 1", IsCompleted = false },
        //         new TaskItem { Id = 2, Title = "Sample Task 2", IsCompleted = true });
        // }
}