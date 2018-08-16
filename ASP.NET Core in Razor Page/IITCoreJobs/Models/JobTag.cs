using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IITCoreJobs.Models
{
    public class JobTag : Entity
    {
        [Required]
        [Display(Name = "Tag Name")]
        public string TagName { get; set; }
    }
}
