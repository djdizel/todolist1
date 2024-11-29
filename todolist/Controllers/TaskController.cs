using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using todolist.Data;
using todolist.Models;

namespace todolist.Controllers;

public class TaskController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<TaskController> _logger;

    public TaskController(ApplicationDbContext context, ILogger<TaskController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var tasks = _context.TaskItems.ToList();
        _logger.LogInformation("Number of tasks retrieved: {Count}", tasks.Count);
        return View(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TaskItem task)
    {
        if (ModelState.IsValid)
        {
            _context.Add(task);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(task);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var task = await _context.TaskItems.FindAsync(id);
        if (task != null)
        {
            _context.TaskItems.Remove(task);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
        var tasks = _context.TaskItems.ToList();
        return View(tasks); // Make sure tasks is not null
    }
    }


