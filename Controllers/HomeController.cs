using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using YARSUWIKI.DOMAIN.Entity;
using YARSUWIKI.Models;

namespace YARSUWIKI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Author author = new Author()
        {
            Name = "Никита",
            Description = "Хуесос"
        };
        return View(author);
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
}