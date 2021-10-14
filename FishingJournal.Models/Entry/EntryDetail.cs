using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingJournal.Models
{
    public class EntryDetail
    {
      
        public int EntryId { get; set; }
        public string Notes { get; set; }

        [Display(Name = "Date of trip")]
        public DateTimeOffset JournalDate { get; set; }

        [Display(Name ="Total fish caught")]
        [Range(0, 999, ErrorMessage = "Cannot be negative")]
        public int TotalFishCaught { get; set; }

        [Display(Name ="Zip Code")]
        [MinLength(5, ErrorMessage = "Must be 5 digits")]
        [MaxLength(5, ErrorMessage = "Must be 5 digits")]
        public string Location { get; set; }

    }
}
