using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IITCoreJobs.Models;

namespace IITCoreJobs.Pages.Jobs
{
    public class EditModel : PageModel
    {
        private readonly IITCoreJobs.Models.IITCoreJobsContext _context;

        public EditModel(IITCoreJobs.Models.IITCoreJobsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Job Job { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Job = await _context.Job
                .Include(j => j.EmploymentStatus)
                .Include(j => j.JobCategory)
                .Include(j => j.JobTag).SingleOrDefaultAsync(m => m.ID == id);

            if (Job == null)
            {
                return NotFound();
            }
           ViewData["EmploymentStatusID"] = new SelectList(_context.EmploymentStatus, "ID", "TypeName");
           ViewData["CategoryID"] = new SelectList(_context.JobCategory, "ID", "CategoryName");
           ViewData["TagID"] = new SelectList(_context.JobTag, "ID", "TagName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Job).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(Job.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool JobExists(Guid id)
        {
            return _context.Job.Any(e => e.ID == id);
        }
    }
}
