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
        public string Content { get; set; }
        [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        public int TotalFishCaught { get; set; }
        public string Location { get; set; }

    }
}
