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
        public string Notes { get; set; }        

        [Display(Name = "Fish Caught")]
        public int TotalFishCaught { get; set; }

        public string Location { get; set; }

        [Display(Name = "Species")]
        public string Species { get; set; }

        [Display(Name = "Lure")]
        public string LureName { get; set; }

    }
}
