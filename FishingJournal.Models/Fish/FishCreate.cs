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
        public string Species { get; set; }

        /* [DataType(DataType.Upload)]
        [Display(Name ="Upload File")]
        public string file { get; set; } */
        
    }
}
