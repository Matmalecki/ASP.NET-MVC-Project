using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNet.Data;
using DotNet.Models;
using Microsoft.AspNetCore.Authorization;

namespace DotNet.Controllers
{
    public class BooksController : Controller
    {
        private readonly IApplicationDbContext _context;

        public BooksController(IApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Books
        [AllowAnonymous]
        public IActionResult Index(string searchString)
        {

            var books = from m in _context.Books.Include(a => a.Author) select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Author.FullName.Contains(searchString)
                || s.YearOfRelease.ToString().Contains(searchString)
                || s.Title.Contains(searchString)
                || (string.IsNullOrEmpty(s.Genre) ? false : s.Genre.Contains(searchString))
                || s.Country.Contains(searchString)
                || s.Isbn.Contains(searchString)
                );

            }
            books.OrderBy(b => b.YearOfRelease);

            return View(books.ToList());
        }

        // GET: Books/Details/5
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Author)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["AuthorID"] = new SelectList(_context.Authors, "ID", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("ID,Title,YearOfRelease,Isbn,Genre,Country,AuthorID")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorID"] = new SelectList(_context.Authors, "ID", "FullName", book.AuthorID);
            return View(book);
        }

        // GET: Books/Edit/5
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var book = _context.FindBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["AuthorID"] = new SelectList(_context.Authors, "ID", "FullName", book.AuthorID);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,YearOfRelease,Isbn,Genre,Country,AuthorID")] Book book)
        {
            if (id != book.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.ID))
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
            ViewData["AuthorID"] = new SelectList(_context.Authors, "ID", "FullName", book.AuthorID);
            return View(book);
        }

        // GET: Books/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Author)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _context.FindBookById(id);
            _context.Delete<Book>(book);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.ID == id);
        }
    }
}
