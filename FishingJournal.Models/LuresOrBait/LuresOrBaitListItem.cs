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
        public int LureId { get; set; }
        public string LureName { get; set; }
    }
}
