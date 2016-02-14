using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheClosestPkm.Models
{
    public class TimeTable
    {
        [ScaffoldColumn(false)]
        public int TimeTableId { get; set; }
        
        public int Time { get; set; }
        public string T1 { get; set; }
        public string T2 { get; set; }
        public string T3 { get; set; }
        public string T4 { get; set; }

        //[ScaffoldColumn(false)]//this will be foreign key
        [ForeignKey("StationsTableId")]
        public int? StationsTableId { get; set; }
        //navigation property
        public virtual StationsTable Station { get; set; }

    }
}
