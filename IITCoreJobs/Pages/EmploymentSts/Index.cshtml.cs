using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IITCoreJobs.Models;

namespace IITCoreJobs.Pages.EmploymentSts
{
    public class IndexModel : PageModel
    {
        private readonly IITCoreJobs.Models.IITCoreJobsContext _context;

        public IndexModel(IITCoreJobs.Models.IITCoreJobsContext context)
        {
            _context = context;
        }

        public IList<EmploymentStatus> EmploymentStatus { get;set; }

        public async Task OnGetAsync()
        {
            EmploymentStatus = await _context.EmploymentStatus.ToListAsync();
        }
    }
}
