using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingJournal.Models
{
    public class EntryListItem
    {
        public int EntryId { get; set; }
        public DateTimeOffset JournalDate { get; set; }
        public string Notes { get; set; }        

        [Display(Name = "Fish Caught")]
        [Range(0, 999, ErrorMessage = "Cannot be 0 or less")]
        public int TotalFishCaught { get; set; }

        [Display(Name = "Zip Code")]
        [MinLength(5, ErrorMessage = "Must be 5 digits")]
        [MaxLength(5, ErrorMessage = "Must be 5 digits")]
        public string Location { get; set; }

        [Display(Name = "Species")]
        public string Species { get; set; }

        [Display(Name = "Lure")]
        public string LureName { get; set; }

    }
}
