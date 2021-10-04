﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingJournal.Data
{
    public class Entry
    {
        [Key]
        public int JournalEntryId { get; set; }
        public Guid OwnerId { get; set; }
        // public DateTime Date { get; set; }
        public int TotalFishCaught { get; set; }
        public int WeatherId { get; set; }
        public int LureId { get; set; }
        public int FishId { get; set; }
        public int StrategyId { get; set; }
        public string Location { get; set; }
        public string Content { get; set; }

    }
}
