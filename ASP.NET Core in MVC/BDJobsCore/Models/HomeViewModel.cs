using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDJobsCore.Models
{
    public class HomeViewModel
    {
        public List<Job> JobsList { get; set; }
        public List<JobCategory> JobCategoryList { get; set; }
    }
}
