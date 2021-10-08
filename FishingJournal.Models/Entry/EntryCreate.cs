using FishingJournal.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingJournal.Models
{
    public class EntryCreate
    {      

        [Required]
        // [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        // [MaxLength (500, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }

        [MaxLength(8000)]
        public string Content { get; set; }

        [Display(Name ="Quantity of fish caught")]
        public int TotalFishCaught { get; set; }
        public int WeatherId { get; set; }

        [ForeignKey(nameof(LuresOrBait))]
        public int LureId { get; set; }

        [ForeignKey(nameof(Fish))]
        public int FishId { get; set; }

        // public int StrategyId { get; set; }
        [Display(Name ="Location Zip Code")]
        public string Location { get; set; }        

        public virtual ICollection<Fish> Fishes { get; set; } = new List<Fish>();
        public virtual ICollection<LuresOrBait> Lures { get; set; } = new List<LuresOrBait>();
    }
}
