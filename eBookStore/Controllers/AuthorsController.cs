using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entity.Database;
using Entity.Models;
using eBookStore.Models;
using Microsoft.IdentityModel.Tokens;
using eBookStore.Utils;
using Microsoft.AspNetCore.Authorization;

namespace eBookStore.Views.Authors
{
    public class AuthorsController : Controller
    {
        private readonly AppDBContext _context;
        HttpClient? _client;
        string _url;
        public AuthorsController( )
        {
            _context = new AppDBContext();
            _client = new HttpClient();
            _url = "https://localhost:7151/api/Authors";
        }
        [Authorize]
        // GET: Authors
        public async Task<IActionResult> Index(FindModel? findModel)
        {
            var abc = findModel;
            var temp = "?$filter=";
            temp += findModel.LastName.IsNullOrEmpty() ? "" : $"LastName eq '{findModel.LastName}'";
            temp += findModel.FirstName.IsNullOrEmpty() ? "" : $"FirstName eq '{findModel.FirstName}'";
            temp += findModel.Phone.IsNullOrEmpty() ? "" : $"Phone eq '{findModel.Phone}'";
            temp += findModel.Address.IsNullOrEmpty() ? "" : $"Address eq '{findModel.Address}'";
            temp += findModel.City.IsNullOrEmpty() ? "" : $"City eq '{findModel.City}'";
            temp += findModel.State.IsNullOrEmpty() ? "" : $"State eq '{findModel.State}'";
            temp += findModel.Zip.IsNullOrEmpty() ? "" : $"Zip eq '{findModel.Zip}'";
            temp += findModel.EmailAddress.IsNullOrEmpty() ? "" : $"EmailAddress eq {findModel.EmailAddress}";
            var urltemp = temp.Length == 9 ? _url : _url + temp;
            var list = await ApiHandler.DeserializeApiResponse<IEnumerable<Author>>(urltemp, HttpMethod.Get);

            var a = await _context.Authors.ToListAsync();
            return View(list);
        }



        // GET: Authors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Authors
                .FirstOrDefaultAsync(m => m.AuthorID == id);
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

        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorID,LastName,FirstName,Phone,Address,City,State,Zip,EmailAddress")] Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Add(author);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuthorID,LastName,FirstName,Phone,Address,City,State,Zip,EmailAddress")] Author author)
        {
            if (id != author.AuthorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(author);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorExists(author.AuthorID))
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Authors
                .FirstOrDefaultAsync(m => m.AuthorID == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.AuthorID == id);
        }
    }
}
