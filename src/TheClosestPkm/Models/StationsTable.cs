using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TheClosestPkm.Models
{
    public class StationsTable
    {
        [ScaffoldColumn(false)]
        public int StationsTableId { get; set; }
        [Required]
        public string StationName { get; set; }

        public virtual ICollection<TimeTable> TimeTable { get; set; }  
    }
}
