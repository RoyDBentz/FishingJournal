using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingJournal.Data
{
    public class LuresOrBait
    {
        [Key]
        public int LureId { get; set; }
        public bool Artificial { get; set; }
        public string ArtificialType { get; set; }
        public double Weight { get; set; }
        public string Color { get; set; }
        public int Depth { get; set; }
    }
}
