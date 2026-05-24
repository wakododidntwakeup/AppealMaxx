
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppealMaxxWeb.Models;
using AppealMaxxWeb.Data;

public class WorkoutsController : Controller
{
    private readonly ApplicationDbContext _context;

    public WorkoutsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: WORKOUTS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Workouts.ToListAsync());
    }

    // GET: WORKOUTS/Details/5
    public async Task<IActionResult> Details(int? workoutid)
    {
        if (workoutid == null)
        {
            return NotFound();
        }

        var workout = await _context.Workouts
            .FirstOrDefaultAsync(m => m.WorkoutId == workoutid);
        if (workout == null)
        {
            return NotFound();
        }

        return View(workout);
    }

    // GET: WORKOUTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: WORKOUTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("WorkoutId,UserId,WorkoutName,DurationMinutes,BurnedCalories,WorkoutDate,User")] Workout workout)
    {
        if (ModelState.IsValid)
        {
            _context.Add(workout);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(workout);
    }

    // GET: WORKOUTS/Edit/5
    public async Task<IActionResult> Edit(int? workoutid)
    {
        if (workoutid == null)
        {
            return NotFound();
        }

        var workout = await _context.Workouts.FindAsync(workoutid);
        if (workout == null)
        {
            return NotFound();
        }
        return View(workout);
    }

    // POST: WORKOUTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? workoutid, [Bind("WorkoutId,UserId,WorkoutName,DurationMinutes,BurnedCalories,WorkoutDate,User")] Workout workout)
    {
        if (workoutid != workout.WorkoutId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(workout);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutExists(workout.WorkoutId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(workout);
    }

    // GET: WORKOUTS/Delete/5
    public async Task<IActionResult> Delete(int? workoutid)
    {
        if (workoutid == null)
        {
            return NotFound();
        }

        var workout = await _context.Workouts
            .FirstOrDefaultAsync(m => m.WorkoutId == workoutid);
        if (workout == null)
        {
            return NotFound();
        }

        return View(workout);
    }

    // POST: WORKOUTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? workoutid)
    {
        var workout = await _context.Workouts.FindAsync(workoutid);
        if (workout != null)
        {
            _context.Workouts.Remove(workout);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool WorkoutExists(int? workoutid)
    {
        return _context.Workouts.Any(e => e.WorkoutId == workoutid);
    }
}
