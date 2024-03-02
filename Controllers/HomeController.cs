using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using YARSUWIKI.DAL.Interfaces;
using YARSUWIKI.DOMAIN.Entity;
using YARSUWIKI.Models;

namespace YARSUWIKI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IAuthorRepository _authorRepository;

    public HomeController(ILogger<HomeController> logger, IAuthorRepository authorRepository)
    {
        _logger = logger;
        _authorRepository = authorRepository;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _authorRepository.Select();
        return View();
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