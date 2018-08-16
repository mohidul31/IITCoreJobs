using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BDJobsCore.Models
{
    public class EmploymentStatus : Entity
    {
        [Required]
        [Display(Name = "Type Name")]
        public string TypeName { get; set; }
    }
}
