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

        [Display(Name = "Date of trip")]
        [DataType(DataType.Date)]
        public DateTimeOffset JournalDate { get; set; }

        [MaxLength(8000)]
        public string Notes { get; set; }

        [Display(Name ="Fish Caught")]
        [Range(0, 999, ErrorMessage ="Cannot be 0 or less")]
        public int TotalFishCaught { get; set; }

        [Display(Name = "Zip Code")]
        //[Range(10001, 99999, ErrorMessage = "Must be 5 digits")]  
        [MinLength(5, ErrorMessage ="Must be 5 digits")]
        [MaxLength(5, ErrorMessage ="Must be 5 digits")]
        public string Location { get; set; }

        [Display(Name = "Species")]
        public int FishId { get; set; }

        [Display(Name = "Lures")]
        public int LureId { get; set; }
        public SelectList Species { get; set; }
        public SelectList Lures { get; set; }

    }
}
