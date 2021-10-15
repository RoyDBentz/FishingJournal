using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingJournal.Models
{
    public class FishListItem
    {
        [Display(Name ="Live Well")]
        public int FishId { get; set; }
        public string Species { get; set; }
    }
}
