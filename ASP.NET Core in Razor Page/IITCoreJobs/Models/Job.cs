using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IITCoreJobs.Models
{
    public class Job : Entity
    {
        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        [Required]
        [Display(Name = "Job Description")]
        public string JobDescription { get; set; }
        [Required]
        [Display(Name = "Job Experience")]
        public string JobExperience { get; set; }

        [Display(Name = "Education Details")]
        public string EducationDetails { get; set; }

        public double Salary { get; set; }
        [Display(Name = "Age Limit")]
        public double AgeLimit { get; set; }

        [Display(Name = "Tag")]
        public Guid? TagID { get; set; }
        [ForeignKey("TagID")]
        public virtual JobTag JobTag { get; set; }

        [Display(Name = "Category")]
        public Guid? CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual JobCategory JobCategory { get; set; }

        [Display(Name = "Employment Type")]
        public Guid? EmploymentStatusID { get; set; }
        [ForeignKey("EmploymentStatusID")]
        public virtual EmploymentStatus EmploymentStatus { get; set; }

        [Display(Name = "Application Last Date")]
        public DateTime? LastDate { get; set; }

        [ScaffoldColumn(false)]
        [Column(TypeName = "Date")]
        public DateTime? SubmitDate { get; set; }


        public Job()
        {
            SubmitDate = DateTime.Now;
        }
    }
}
