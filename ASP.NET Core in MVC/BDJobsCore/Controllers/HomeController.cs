using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BDJobsCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BDJobsCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly JobContext _context;

        public HomeController(JobContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(Guid ? category)
        {
            HomeViewModel model = new HomeViewModel();

            IQueryable<Job> jobContext = _context.Job.Include(j => j.EmploymentStatus).
                Include(j => j.JobCategory).Include(j => j.JobTag).OrderBy(x => x.SubmitDate);

            if (category.HasValue)
            {
                jobContext = jobContext.Where(x => x.JobCategory.ID == category.Value);
            }
            model.JobsList = await jobContext.ToListAsync();
            model.JobCategoryList = await _context.JobCategory.ToListAsync();
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
