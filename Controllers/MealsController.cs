
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppealMaxxWeb.Models;
using AppealMaxxWeb.Data;

public class MealsController : Controller
{
    private readonly ApplicationDbContext _context;

    public MealsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: MEALS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Meals.ToListAsync());
    }

    // GET: MEALS/Details/5
    public async Task<IActionResult> Details(int? mealid)
    {
        if (mealid == null)
        {
            return NotFound();
        }

        var meal = await _context.Meals
            .FirstOrDefaultAsync(m => m.MealId == mealid);
        if (meal == null)
        {
            return NotFound();
        }

        return View(meal);
    }

    // GET: MEALS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: MEALS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("MealId,UserId,MealName,Calories,MealDate,User")] Meal meal)
    {
        if (ModelState.IsValid)
        {
            _context.Add(meal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(meal);
    }

    // GET: MEALS/Edit/5
    public async Task<IActionResult> Edit(int? mealid)
    {
        if (mealid == null)
        {
            return NotFound();
        }

        var meal = await _context.Meals.FindAsync(mealid);
        if (meal == null)
        {
            return NotFound();
        }
        return View(meal);
    }

    // POST: MEALS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? mealid, [Bind("MealId,UserId,MealName,Calories,MealDate,User")] Meal meal)
    {
        if (mealid != meal.MealId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(meal);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealExists(meal.MealId))
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
        return View(meal);
    }

    // GET: MEALS/Delete/5
    public async Task<IActionResult> Delete(int? mealid)
    {
        if (mealid == null)
        {
            return NotFound();
        }

        var meal = await _context.Meals
            .FirstOrDefaultAsync(m => m.MealId == mealid);
        if (meal == null)
        {
            return NotFound();
        }

        return View(meal);
    }

    // POST: MEALS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? mealid)
    {
        var meal = await _context.Meals.FindAsync(mealid);
        if (meal != null)
        {
            _context.Meals.Remove(meal);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MealExists(int? mealid)
    {
        return _context.Meals.Any(e => e.MealId == mealid);
    }
}
