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
    public class JobsController : Controller
    {
        private readonly JobContext _context;

        public JobsController(JobContext context)
        {
            _context = context;
        }

        // GET: Jobs
        public async Task<IActionResult> Index()
        {
            var jobContext = _context.Job.Include(j => j.EmploymentStatus).
                Include(j => j.JobCategory).Include(j => j.JobTag).OrderBy( x => x.SubmitDate);
            return View(await jobContext.ToListAsync());
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Job
                .Include(j => j.EmploymentStatus)
                .Include(j => j.JobCategory)
                .Include(j => j.JobTag)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: Jobs/Create
        public IActionResult Create()
        {
            ViewData["EmploymentStatusID"] = new SelectList(_context.EmploymentStatus, "ID", "TypeName");
            ViewData["CategoryID"] = new SelectList(_context.JobCategory, "ID", "CategoryName");
            ViewData["TagID"] = new SelectList(_context.JobTag, "ID", "TagName");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobTitle,JobDescription,JobResponsibility,EducationDetails,Salary,AgeLimit,TagID,CategoryID,EmploymentStatusID,LastDate,ID")] Job job)
        {
            if (ModelState.IsValid)
            {
                job.ID = Guid.NewGuid();
                _context.Add(job);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmploymentStatusID"] = new SelectList(_context.EmploymentStatus, "ID", "TypeName", job.EmploymentStatusID);
            ViewData["CategoryID"] = new SelectList(_context.JobCategory, "ID", "CategoryName", job.CategoryID);
            ViewData["TagID"] = new SelectList(_context.JobTag, "ID", "TagName", job.TagID);
            return View(job);
        }

        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Job.SingleOrDefaultAsync(m => m.ID == id);
            if (job == null)
            {
                return NotFound();
            }
            ViewData["EmploymentStatusID"] = new SelectList(_context.EmploymentStatus, "ID", "TypeName", job.EmploymentStatusID);
            ViewData["CategoryID"] = new SelectList(_context.JobCategory, "ID", "CategoryName", job.CategoryID);
            ViewData["TagID"] = new SelectList(_context.JobTag, "ID", "TagName", job.TagID);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("JobTitle,JobDescription,JobResponsibility,EducationDetails,Salary,AgeLimit,TagID,CategoryID,EmploymentStatusID,LastDate,ID")] Job job)
        {
            if (id != job.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.ID))
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
            ViewData["EmploymentStatusID"] = new SelectList(_context.EmploymentStatus, "ID", "TypeName", job.EmploymentStatusID);
            ViewData["CategoryID"] = new SelectList(_context.JobCategory, "ID", "CategoryName", job.CategoryID);
            ViewData["TagID"] = new SelectList(_context.JobTag, "ID", "TagName", job.TagID);
            return View(job);
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Job
                .Include(j => j.EmploymentStatus)
                .Include(j => j.JobCategory)
                .Include(j => j.JobTag)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var job = await _context.Job.SingleOrDefaultAsync(m => m.ID == id);
            _context.Job.Remove(job);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobExists(Guid id)
        {
            return _context.Job.Any(e => e.ID == id);
        }
    }
}
