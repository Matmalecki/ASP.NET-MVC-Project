using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNet.Data;
using Project.Models;
using Microsoft.AspNetCore.Authorization;

namespace DotNet.Controllers
{
    [Authorize(Roles = "User")]
    public class AuthorsController : Controller
    {
        private readonly IApplicationDbContext _context;

        public AuthorsController(IApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Authors
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                var authors = from m in _context.Authors where m.FullName.Contains(searchString)
                          || (string.IsNullOrEmpty(m.Email) ? false : m.Email.Contains(searchString)) 
                          || m.DateOfBirth.ToString().Contains(searchString)
                          select m;

                authors.OrderBy(s => s.DateOfBirth);

                return View(await authors.ToListAsync());
            }
            else
            {
                var authors = from m in _context.Authors select m;
                authors.OrderBy(s => s.DateOfBirth);

                return View(await authors.ToListAsync());

            }

        }
        // GET: Authors/Details/5
        [Authorize(Roles = "Admin,User")]
        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var author = _context.FindAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // GET: Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LastName,FirstName,DateOfBirth,Email")] Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Add(author);
                await _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Authors/Edit/5
        public IActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var author = _context.FindAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LastName,FirstName,DateOfBirth,Email")] Author author)
        {
            if (id != author.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(author);
                    await _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorExists(author.ID))
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
            return View(author);
        }

        // GET: Authors/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = _context.FindAuthorById(id.Value);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            var author = _context.FindAuthorById(id);
            _context.Delete<Author>(author);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.ID == id);
        }
    }
}
