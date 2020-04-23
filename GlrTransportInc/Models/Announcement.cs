using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlrTransportInc.Models
{
    public class Announcement
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime DatePosted { get; set; }
        [Required]
        public string Post { get; set; }
    }
}
