using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class CourseController : Controller
{
    private readonly LmsContext _context;

    public CourseController(LmsContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var courses = _context.Courses.Include(c => c.Instructor);
        return View(await courses.ToListAsync());
    }

    public IActionResult Create()
    {
        ViewData["Instructors"] = new SelectList(_context.Instructors, "InstructorId", "Name");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Course course)
    {
        if (ModelState.IsValid)
        {
            _context.Add(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["Instructors"] = new SelectList(_context.Instructors, "InstructorId", "Name", course.InstructorId);
        return View(course);
    }
}
