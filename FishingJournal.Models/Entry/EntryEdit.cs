﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingJournal.Models
{
    public class EntryEdit
    {
        public int EntryId { get; set; }
        public DateTimeOffset JournalDate { get; set; }
        public string Notes { get; set; }

    }
}
