using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BDJobsCore.Models;

namespace BDJobsCore.Models
{
    public class JobContext : DbContext
    {
        public JobContext(DbContextOptions<JobContext> options) : base(options)
        {
        }

        public JobContext()
        {
        }

        public virtual DbSet<JobCategory> JobCategory { get; set; }
        public virtual DbSet<JobTag> JobTag { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<EmploymentStatus> EmploymentStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Remove Cascade Delete
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                            .SelectMany(t => t.GetForeignKeys())
                            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=BDJobsDB;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
