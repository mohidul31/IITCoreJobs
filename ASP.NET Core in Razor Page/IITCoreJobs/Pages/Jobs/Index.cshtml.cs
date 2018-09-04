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
    public class IndexModel : PageModel
    {
        private readonly IITCoreJobs.Models.IITCoreJobsContext _context;

        public IndexModel(IITCoreJobs.Models.IITCoreJobsContext context)
        {
            _context = context;
        }

        public IList<Job> Job { get;set; }

        public async Task OnGetAsync()
        {
            Job = await _context.Job
                .Include(j => j.EmploymentStatus)
                .Include(j => j.JobCategory)
                .Include(j => j.JobTag).OrderBy(x => x.SubmitDate).ToListAsync();
        }
    }
}
