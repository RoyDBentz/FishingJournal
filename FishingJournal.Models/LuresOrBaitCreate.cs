using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingJournal.Models
{
    public class LuresOrBaitCreate
    {        
        public int LureId { get; set; }
        public string LureName { get; set; }        
        public string Content { get; set; }
    }
}
