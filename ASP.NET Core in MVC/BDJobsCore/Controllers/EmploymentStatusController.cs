using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BDJobsCore.Models;

namespace BDJobsCore.Controllers
{
    public class EmploymentStatusController : Controller
    {
        private readonly JobContext _context;

        public EmploymentStatusController(JobContext context)
        {
            _context = context;
        }

        // GET: EmploymentStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmploymentStatus.ToListAsync());
        }

        // GET: EmploymentStatus/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employmentStatus = await _context.EmploymentStatus
                .SingleOrDefaultAsync(m => m.ID == id);
            if (employmentStatus == null)
            {
                return NotFound();
            }

            return View(employmentStatus);
        }

        // GET: EmploymentStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmploymentStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeName,ID")] EmploymentStatus employmentStatus)
        {
            if (ModelState.IsValid)
            {
                employmentStatus.ID = Guid.NewGuid();
                _context.Add(employmentStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employmentStatus);
        }

        // GET: EmploymentStatus/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employmentStatus = await _context.EmploymentStatus.SingleOrDefaultAsync(m => m.ID == id);
            if (employmentStatus == null)
            {
                return NotFound();
            }
            return View(employmentStatus);
        }

        // POST: EmploymentStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TypeName,ID")] EmploymentStatus employmentStatus)
        {
            if (id != employmentStatus.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employmentStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmploymentStatusExists(employmentStatus.ID))
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
            return View(employmentStatus);
        }

        // GET: EmploymentStatus/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employmentStatus = await _context.EmploymentStatus
                .SingleOrDefaultAsync(m => m.ID == id);
            if (employmentStatus == null)
            {
                return NotFound();
            }

            return View(employmentStatus);
        }

        // POST: EmploymentStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var employmentStatus = await _context.EmploymentStatus.SingleOrDefaultAsync(m => m.ID == id);
            _context.EmploymentStatus.Remove(employmentStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmploymentStatusExists(Guid id)
        {
            return _context.EmploymentStatus.Any(e => e.ID == id);
        }
    }
}
