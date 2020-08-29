using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlrTransportInc.Models
{
    public class EventListing
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EventDate { get; set; }

        public string Post { get; set; }
    }
}
