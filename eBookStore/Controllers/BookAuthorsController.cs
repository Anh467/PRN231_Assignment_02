using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entity.Database;
using Entity.Models;
using eBookStore.Utils;
using Microsoft.AspNetCore.Authorization;

namespace eBookStore.Controllers
{
    public class BookAuthorsController : Controller
    {
        private readonly AppDBContext _context;
        HttpClient? _client;
        string _url;
        public BookAuthorsController()
        {
            _context = new AppDBContext();
            _client = new HttpClient();
            _url = "https://localhost:7151/api/BookAuthors";
        }
        [Authorize]
        // GET: BookAuthors
        public async Task<IActionResult> Index()
        {
            var bookAuthors = ApiHandler.DeserializeApiResponse<IEnumerable<BookAuthor>>(_url, HttpMethod.Get);
            var a = _context.BookAuthors.ToList();
            return View(a);
        }

        // GET: BookAuthors/Details/5
        public async Task<IActionResult> Details(int? id1, int? id2)
        {
            if (id1 == null || id2 == null)
            {
                return NotFound();
            }

            var bookAuthor = await _context.BookAuthors
                .Include(b => b.Author)
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.AuthorId == id2 && m.BookId == id1);
            if (bookAuthor == null)
            {
                return NotFound();
            }

            return View(bookAuthor);
        }

        // GET: BookAuthors/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorID", "EmailAddress");
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Notes");
            return View();
        }

        // POST: BookAuthors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorId,BookId,AuthorOrder,RoyalityPercentage")] BookAuthor bookAuthor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(bookAuthor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorID", "EmailAddress", bookAuthor.AuthorId);
                ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Notes", bookAuthor.BookId);
                return View(bookAuthor);
            }
            catch(Exception ex)
            {
                return Redirect("~/BookAuthors");
            }
        }

        // GET: BookAuthors/Edit/5
        public async Task<IActionResult> Edit(int? id1, int? id2)
        {
            if (id1 == null || id2 == null)
            {
                return NotFound();
            }

            var bookAuthor = await _context.BookAuthors.FindAsync(id2, id1);
            if (bookAuthor == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorID", "EmailAddress", bookAuthor.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Notes", bookAuthor.BookId);
            return View(bookAuthor);
        }

        // POST: BookAuthors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("AuthorId,BookId,AuthorOrder,RoyalityPercentage")] BookAuthor bookAuthor)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Entry(bookAuthor).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookAuthorExists(bookAuthor.AuthorId))
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
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorID", "EmailAddress", bookAuthor.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Notes", bookAuthor.BookId);
            return View(bookAuthor);
        }

        // GET: BookAuthors/Delete/5
        public async Task<IActionResult> Delete(int? id1, int? id2)
        {
            if (id1 == null || id2 == null)
            {
                return NotFound();
            }

            var bookAuthor = await _context.BookAuthors
                .Include(b => b.Author)
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.AuthorId == id2 && m.BookId == id1);
            if (bookAuthor == null)
            {
                return NotFound();
            }

            return View(bookAuthor);
        }

        // POST: BookAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? AuthorId, int? BookId)
        {
            var bookAuthor = await _context.BookAuthors.FindAsync(AuthorId, BookId);
            if (bookAuthor != null)
            {
                _context.BookAuthors.Remove(bookAuthor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookAuthorExists(int id)
        {
            return _context.BookAuthors.Any(e => e.AuthorId == id);
        }
    }
}
