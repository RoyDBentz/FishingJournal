using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingJournal.Data
{
    public class Entry
    {
        [Key]
        public int EntryId { get; set; }
        public Guid OwnerId { get; set; }
       
        public DateTimeOffset? ModifiedUtc { get; set; }
        public int TotalFishCaught { get; set; }
        public int WeatherId { get; set; }

       // [ForeignKey(nameof(LuresOrBait))]
        public int LureId { get; set; }

        // [ForeignKey(nameof(Fish))]
        public int FishId { get; set; }

        public int StrategyId { get; set; }
        public string Location { get; set; }
        public string Content { get; set; }

        public virtual ICollection<Fish> Fishes { get; set; } = new List<Fish>();
        public virtual ICollection<LuresOrBait> Lures { get; set; } = new List<LuresOrBait>();
        
    }
}
