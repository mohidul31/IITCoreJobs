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
    public class IndexModel : PageModel
    {
        private readonly IITCoreJobs.Models.IITCoreJobsContext _context;

        public IndexModel(IITCoreJobs.Models.IITCoreJobsContext context)
        {
            _context = context;
        }

        public IList<JobTag> JobTag { get;set; }

        public async Task OnGetAsync()
        {
            JobTag = await _context.JobTag.ToListAsync();
        }
    }
}
