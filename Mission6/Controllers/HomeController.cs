using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6.Models;

namespace Mission6.Controllers;

public class HomeController : Controller
{
    private MovieApplicationContext _context;
    
    public HomeController(MovieApplicationContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Add()
    {
        ViewBag.Category = _context.Categories.ToList();
        return View("Add", new Movie());
    }

    [HttpPost]
    public IActionResult Add(Movie response)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();

            return View("Confirmation", response);
        }
        else
        {
            ViewBag.Category = _context.Categories.ToList();
            return View("Add", response);
        }
    }

    
    public IActionResult About()
    {
        return View();
    }
    
    public IActionResult Catalog()
    {
        var applications = _context.Movies
            .Include(m => m.Category)
            .OrderBy(x => x.Title)
            .ToList();

        return View(applications);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Movies 
            .Single(m => m.MovieId == id);
        
        ViewBag.Category = _context.Categories.ToList();
        
        return View("Add", recordToEdit);
    }

    [HttpPost]
    public IActionResult Edit(Movie recordToEdit)
    {
        _context.Update(recordToEdit);
        _context.SaveChanges();
        
        return RedirectToAction("Catalog");
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies
            .Single(m => m.MovieId == id);
        return View(recordToDelete);
    }
    
    [HttpPost]
    public IActionResult Delete(Movie movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        
        return RedirectToAction("Catalog");
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}