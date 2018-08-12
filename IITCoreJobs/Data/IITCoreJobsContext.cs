﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IITCoreJobs.Models;

namespace IITCoreJobs.Models
{
    public class IITCoreJobsContext : DbContext
    {
        public IITCoreJobsContext (DbContextOptions<IITCoreJobsContext> options)
            : base(options)
        {
        }
        public IITCoreJobsContext()
        {
        }

        public DbSet<JobCategory> JobCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=IITJobsDB;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<IITCoreJobs.Models.JobTag> JobTag { get; set; }
    }
}
