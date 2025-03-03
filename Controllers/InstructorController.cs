using LMS.Models;
using Microsoft.AspNetCore.Mvc;

public class InstructorController : Controller
{
    private readonly LmsContext _context;

    public InstructorController(LmsContext context)
    {
        _context = context;
    }

    // GET: Instructor/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Instructor/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name")] Instructor instructor)
    {
        if (ModelState.IsValid)
        {
            _context.Add(instructor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); // Change to any other appropriate view if Index isn't available yet.
        }
        return View(instructor);
    }
}
