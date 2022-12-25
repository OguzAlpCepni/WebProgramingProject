using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProgramingProject.Data;
using WebProgramingProject.Models;

namespace WebProgramingProject.Controllers
{
    public class MovieCategoriesController : Controller
    {
        private readonly MovieDbContext _context;

        public MovieCategoriesController(MovieDbContext context)
        {
            _context = context;
        }

        // GET: MovieCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.MovieCategory.ToListAsync());
        }

        // GET: MovieCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MovieCategory == null)
            {
                return NotFound();
            }

            var movieCategory = await _context.MovieCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieCategory == null)
            {
                return NotFound();
            }

            return View(movieCategory);
        }

        // GET: MovieCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovieCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] MovieCategory movieCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieCategory);
        }

        // GET: MovieCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MovieCategory == null)
            {
                return NotFound();
            }

            var movieCategory = await _context.MovieCategory.FindAsync(id);
            if (movieCategory == null)
            {
                return NotFound();
            }
            return View(movieCategory);
        }

        // POST: MovieCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] MovieCategory movieCategory)
        {
            if (id != movieCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieCategoryExists(movieCategory.Id))
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
            return View(movieCategory);
        }

        // GET: MovieCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MovieCategory == null)
            {
                return NotFound();
            }

            var movieCategory = await _context.MovieCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieCategory == null)
            {
                return NotFound();
            }

            return View(movieCategory);
        }

        // POST: MovieCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MovieCategory == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MovieCategory'  is null.");
            }
            var movieCategory = await _context.MovieCategory.FindAsync(id);
            if (movieCategory != null)
            {
                _context.MovieCategory.Remove(movieCategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieCategoryExists(int id)
        {
            return _context.MovieCategory.Any(e => e.Id == id);
        }
    }
}
