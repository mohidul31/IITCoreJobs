using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IITCoreJobs.Models;

namespace IITCoreJobs.Pages.EmploymentSts
{
    public class EditModel : PageModel
    {
        private readonly IITCoreJobs.Models.IITCoreJobsContext _context;

        public EditModel(IITCoreJobs.Models.IITCoreJobsContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EmploymentStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmploymentStatusExists(EmploymentStatus.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EmploymentStatusExists(Guid id)
        {
            return _context.EmploymentStatus.Any(e => e.ID == id);
        }
    }
}
