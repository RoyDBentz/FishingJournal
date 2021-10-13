using FishingJournal.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FishingJournal.Models
{
    public class EntryCreate
    {      
        public int EntryId { get; set; }

        [MaxLength(8000)]
        public string Notes { get; set; }

        [Display(Name ="Fish Caught")]
        public int TotalFishCaught { get; set; }
        
        [Display(Name ="Location Zip Code")]
        public string Location { get; set; }
        [Display(Name = "Species")]
        public int FishId { get; set; }
        [Display(Name = "Lures")]
        public int LureId { get; set; }
        public SelectList Species { get; set; }
        public SelectList Lures { get; set; }

    }
}
