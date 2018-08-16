using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IITCoreJobs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IITCoreJobs.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IITCoreJobsContext _context;
        private readonly IITCoreJobsContext _context2;

        public IndexModel(IITCoreJobsContext context)
        {
            _context = context;
            _context2 = context;
        }

        public IList<Job> JobList { get; set; }
        public IList<JobCategory> JobCategoryList { get; set; }

        public  void OnGet(Guid ? category, Guid? jobtype ,Guid? tag)
        {
            IQueryable<Job> jobData = _context.Job.Include(j => j.EmploymentStatus).
                Include(j => j.JobCategory).Include(j => j.JobTag).OrderBy(x => x.SubmitDate);

            if (category.HasValue)
            {
                jobData = jobData.Where(x => x.JobCategory.ID == category.Value);
            }
            if (jobtype.HasValue)
            {
                jobData = jobData.Where(x => x.EmploymentStatus.ID == jobtype.Value);
            }

            if (tag.HasValue)
            {
                jobData = jobData.Where(x => x.JobTag.ID == tag.Value);
            }
            JobList =  jobData.ToList();
            
            JobCategoryList =  _context2.JobCategory.ToList();
        }
    }
}
