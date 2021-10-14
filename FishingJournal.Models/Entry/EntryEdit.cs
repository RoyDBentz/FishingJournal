using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingJournal.Models
{
    public class EntryEdit
    {
        public int EntryId { get; set; }

        [Display(Name = "Date of trip")]
        public DateTimeOffset JournalDate { get; set; }

        public string Notes { get; set; }

    }
}
