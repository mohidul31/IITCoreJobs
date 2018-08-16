using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IITCoreJobs.Models;

namespace IITCoreJobs.Pages.Jobs
{
    public class CreateModel : PageModel
    {
        private readonly IITCoreJobs.Models.IITCoreJobsContext _context;

        public CreateModel(IITCoreJobs.Models.IITCoreJobsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["EmploymentStatusID"] = new SelectList(_context.EmploymentStatus, "ID", "TypeName");
        ViewData["CategoryID"] = new SelectList(_context.JobCategory, "ID", "CategoryName");
        ViewData["TagID"] = new SelectList(_context.JobTag, "ID", "TagName");
            return Page();
        }

        [BindProperty]
        public Job Job { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Job.Add(Job);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}