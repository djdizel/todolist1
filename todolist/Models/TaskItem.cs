using System.ComponentModel.DataAnnotations.Schema;

namespace todolist.Models;
[Table("TaskItems")]
public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Status { get; set; } = "Pending";
    public bool IsCompleted { get; set; } = false;
}