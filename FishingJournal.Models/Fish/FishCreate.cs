using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingJournal.Models
{
    public class FishCreate
    {
        public int FishId { get; set; }
        [Display(Name ="Fish Species")]
        public string Species { get; set; }
        [Display(Name ="Average Length in inches")]
        public double AverageSize { get; set; }
        [Display(Name ="Average Weight in lbs")]
        public double AverageWeight { get; set; }

    }
}
