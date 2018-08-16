using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BDJobsCore.Models
{
    public class JobCategory : Entity
    {
        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        public IEnumerable<Job> JobList { get; set; }
    }
}
