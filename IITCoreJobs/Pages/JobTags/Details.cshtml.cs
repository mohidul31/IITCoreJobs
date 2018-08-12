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
    public class DetailsModel : PageModel
    {
        private readonly IITCoreJobs.Models.IITCoreJobsContext _context;

        public DetailsModel(IITCoreJobs.Models.IITCoreJobsContext context)
        {
            _context = context;
        }

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
    }
}
