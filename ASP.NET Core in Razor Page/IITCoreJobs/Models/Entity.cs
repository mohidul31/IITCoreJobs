using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IITCoreJobs.Models
{
    public class Entity
    {
        public Entity()
        {
            ID = Guid.NewGuid();
        }
        [Key]
        public Guid ID { get; set; }
    }
}
