using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IITCoreJobs.Models;

namespace IITCoreJobs.Pages.JobTags
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
        public JobTag JobTag { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.JobTag.Add(JobTag);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}