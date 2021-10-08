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
        public string Content { get; set; }

        public int TotalFishCaught { get; set; }
        public string Location { get; set; }

    }
}
