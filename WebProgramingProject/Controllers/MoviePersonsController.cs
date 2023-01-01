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
    public class MoviePersonsController : Controller
    {
        private readonly MovieDbContext _context;

        public MoviePersonsController(MovieDbContext context)
        {
            _context = context;
        }

        // GET: MoviePersons
        public async Task<IActionResult> Index()
        {
            var movieDbContext = _context.MoviePerson.Include(m => m.Movie).Include(m => m.Person);
            return View(await movieDbContext.ToListAsync());
        }

        // GET: MoviePersons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MoviePerson == null)
            {
                return NotFound();
            }

            var moviePerson = await _context.MoviePerson
                .Include(m => m.Movie)
                .Include(m => m.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moviePerson == null)
            {
                return NotFound();
            }

            return View(moviePerson);
        }

        // GET: MoviePersons/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Explain");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id");
            return View();
        }

        // POST: MoviePersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,PersonId,Role,Id")] MoviePerson moviePerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moviePerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Explain", moviePerson.MovieId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", moviePerson.PersonId);
            return View(moviePerson);
        }

        // GET: MoviePersons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MoviePerson == null)
            {
                return NotFound();
            }

            var moviePerson = await _context.MoviePerson.FindAsync(id);
            if (moviePerson == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Explain", moviePerson.MovieId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", moviePerson.PersonId);
            return View(moviePerson);
        }

        // POST: MoviePersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,PersonId,Role,Id")] MoviePerson moviePerson)
        {
            if (id != moviePerson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moviePerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoviePersonExists(moviePerson.Id))
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
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Explain", moviePerson.MovieId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", moviePerson.PersonId);
            return View(moviePerson);
        }

        // GET: MoviePersons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MoviePerson == null)
            {
                return NotFound();
            }

            var moviePerson = await _context.MoviePerson
                .Include(m => m.Movie)
                .Include(m => m.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moviePerson == null)
            {
                return NotFound();
            }

            return View(moviePerson);
        }

        // POST: MoviePersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MoviePerson == null)
            {
                return Problem("Entity set 'MovieDbContext.MoviePerson'  is null.");
            }
            var moviePerson = await _context.MoviePerson.FindAsync(id);
            if (moviePerson != null)
            {
                _context.MoviePerson.Remove(moviePerson);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoviePersonExists(int id)
        {
            return _context.MoviePerson.Any(e => e.Id == id);
        }
    }
}
