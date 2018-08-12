using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IITCoreJobs.Models;

namespace IITCoreJobs.Pages.JobCategories
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
            return Page();
        }

        [BindProperty]
        public JobCategory JobCategory { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.JobCategory.Add(JobCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}