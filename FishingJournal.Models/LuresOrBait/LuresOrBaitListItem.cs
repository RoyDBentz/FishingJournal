using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingJournal.Models
{
    public class LuresOrBaitListItem
    {        

        public bool Artificial { get; set; }

        [Display(Name = "Lure Name")]
        public string LureName { get; set; }

        public string Color { get; set; }

        public string ArtificialType { get; set; }

        [Display(Name = "Weight in oz")]
        public double Weight { get; set; }

        [Display(Name = "Depth in ft")]
        public int Depth { get; set; }
    }
}
