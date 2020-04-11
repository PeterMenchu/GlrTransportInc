using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlrTransportInc.Models
{
    public class Announcement
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime DatePosted { get; set; }
        public string Post { get; set; }
    }
}
