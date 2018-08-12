using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IITCoreJobs.Models;

namespace IITCoreJobs.Pages.JobCategories
{
    public class DetailsModel : PageModel
    {
        private readonly IITCoreJobs.Models.IITCoreJobsContext _context;

        public DetailsModel(IITCoreJobs.Models.IITCoreJobsContext context)
        {
            _context = context;
        }

        public JobCategory JobCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            JobCategory = await _context.JobCategory.SingleOrDefaultAsync(m => m.ID == id);

            if (JobCategory == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
