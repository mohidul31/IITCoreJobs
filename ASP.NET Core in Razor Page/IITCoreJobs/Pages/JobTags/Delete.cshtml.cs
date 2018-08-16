using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IITCoreJobs.Models;

namespace IITCoreJobs.Pages.JobTags
{
    public class DeleteModel : PageModel
    {
        private readonly IITCoreJobs.Models.IITCoreJobsContext _context;

        public DeleteModel(IITCoreJobs.Models.IITCoreJobsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public JobTag JobTag { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            JobTag = await _context.JobTag.SingleOrDefaultAsync(m => m.ID == id);

            if (JobTag == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            JobTag = await _context.JobTag.FindAsync(id);

            if (JobTag != null)
            {
                _context.JobTag.Remove(JobTag);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
