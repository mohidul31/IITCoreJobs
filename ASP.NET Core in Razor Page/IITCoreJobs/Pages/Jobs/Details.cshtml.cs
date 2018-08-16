using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IITCoreJobs.Models;

namespace IITCoreJobs.Pages.Jobs
{
    public class DetailsModel : PageModel
    {
        private readonly IITCoreJobs.Models.IITCoreJobsContext _context;

        public DetailsModel(IITCoreJobs.Models.IITCoreJobsContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
