using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingJournal.Data
{
    public class Fish
    {
        [Key]
        public int FishId { get; set; }
        public Guid OwnerId { get; set; }
        public string Species { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }
    }
}
