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
    public class DeleteModel : PageModel
    {
        private readonly IITCoreJobs.Models.IITCoreJobsContext _context;

        public DeleteModel(IITCoreJobs.Models.IITCoreJobsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EmploymentStatus EmploymentStatus { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmploymentStatus = await _context.EmploymentStatus.SingleOrDefaultAsync(m => m.ID == id);

            if (EmploymentStatus == null)
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

            EmploymentStatus = await _context.EmploymentStatus.FindAsync(id);

            if (EmploymentStatus != null)
            {
                _context.EmploymentStatus.Remove(EmploymentStatus);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
