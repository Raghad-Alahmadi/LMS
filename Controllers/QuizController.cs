using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class QuizController : Controller
{
    private readonly LmsContext _context;

    public QuizController(LmsContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var quizzes = _context.Quizzes.Include(q => q.Course);
        return View(await quizzes.ToListAsync());
    }

    public IActionResult Create()
    {
        ViewData["Courses"] = new SelectList(_context.Courses, "CourseId", "Title");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Quiz quiz)
    {
        if (ModelState.IsValid)
        {
            _context.Add(quiz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["Courses"] = new SelectList(_context.Courses, "CourseId", "Title", quiz.CourseId);
        return View(quiz);
    }
}
