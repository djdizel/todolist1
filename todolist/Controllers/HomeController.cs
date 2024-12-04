using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using todolist.Data;
using todolist.Models;

namespace todolist.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var tasks = _context.TaskItems.ToList();

        // Проверка, если список пустой или null
        if (tasks == null || !tasks.Any())
        {
            Console.WriteLine("TaskItems is null or empty.");
        }
        else
        {
            foreach (var task in tasks)
            {
                Console.WriteLine($"Task: {task.Title}, Completed: {task.IsCompleted}");
            }
        }

        // Передаем данные в представление
        return View(tasks);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    [HttpPost]
    public IActionResult Create(string Title)
    {
        if (!string.IsNullOrEmpty(Title))
        {
            // Создаем новую задачу
            var task = new TaskItem
            {
                Title = Title,
                IsCompleted = false,
                Status = "Pending"
            };

            // Сохраняем задачу в базу данных
            _context.TaskItems.Add(task);
            _context.SaveChanges();
        }

        // Перенаправляем на метод Index для обновления списка задач
        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult DeleteTask(int id)
    {
        var task = _context.TaskItems.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            _context.TaskItems.Remove(task);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

}
