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
    public class JobTagsController : Controller
    {
        private readonly JobContext _context;

        public JobTagsController(JobContext context)
        {
            _context = context;
        }

        // GET: JobTags
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobTag.ToListAsync());
        }

        // GET: JobTags/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobTag = await _context.JobTag
                .SingleOrDefaultAsync(m => m.ID == id);
            if (jobTag == null)
            {
                return NotFound();
            }

            return View(jobTag);
        }

        // GET: JobTags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TagName,ID")] JobTag jobTag)
        {
            if (ModelState.IsValid)
            {
                jobTag.ID = Guid.NewGuid();
                _context.Add(jobTag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobTag);
        }

        // GET: JobTags/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobTag = await _context.JobTag.SingleOrDefaultAsync(m => m.ID == id);
            if (jobTag == null)
            {
                return NotFound();
            }
            return View(jobTag);
        }

        // POST: JobTags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TagName,ID")] JobTag jobTag)
        {
            if (id != jobTag.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobTag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobTagExists(jobTag.ID))
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
            return View(jobTag);
        }

        // GET: JobTags/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobTag = await _context.JobTag
                .SingleOrDefaultAsync(m => m.ID == id);
            if (jobTag == null)
            {
                return NotFound();
            }

            return View(jobTag);
        }

        // POST: JobTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var jobTag = await _context.JobTag.SingleOrDefaultAsync(m => m.ID == id);
            _context.JobTag.Remove(jobTag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobTagExists(Guid id)
        {
            return _context.JobTag.Any(e => e.ID == id);
        }
    }
}
