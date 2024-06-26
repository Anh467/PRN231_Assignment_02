﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entity.Database;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using static Entity.Models.ModelConst;
using System.Security.Claims;

namespace eBookStore.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDBContext _context;
        HttpClient? _client;
        string _url;
        public UsersController()
        {
            _context = new AppDBContext();
        }
        [Authorize]
        // GET: Users
        public async Task<IActionResult> Index()
        {
            var role = User.Claims.SingleOrDefault(a => a.Type == ClaimTypes.Role)?.Value;
            if (role != "admin")
                return Redirect("~/");
            var appDBContext = _context.Users.Include(u => u.Publisher).Include(u => u.Role);
            return View(await appDBContext.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Publisher)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["PubId"] = new SelectList(_context.Publishers, "PubId", "PublisherName");
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleDesc");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,EmailAddress,Password,Source,FirstName,MiddleName,LastName,RoleId,PubId,HireDate")] User user)
        {
            var temp = _context.Users.SingleOrDefault(a => a.EmailAddress == user.EmailAddress);
            if(temp != null)
                return Redirect("~/Users");
            if (ModelState.IsValid)
            {
                user.HireDate = DateTime.Now;
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PubId"] = new SelectList(_context.Publishers, "PubId", "PublisherName", user.PubId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleDesc", user.RoleId);
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["PubId"] = new SelectList(_context.Publishers, "PubId", "PublisherName", user.PubId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleDesc", user.RoleId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,EmailAddress,Password,Source,FirstName,MiddleName,LastName,RoleId,PubId,HireDate")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
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
            ViewData["PubId"] = new SelectList(_context.Publishers, "PubId", "PublisherName", user.PubId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleDesc", user.RoleId);
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Publisher)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
