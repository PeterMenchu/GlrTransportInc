using System;
using System.ComponentModel.DataAnnotations;
namespace GlrTransportInc.Models
{
    public enum FbStatus
    {
        Pending,
        Confirmed,
        Completed,
        Cancelled,
        NA
    }

    public class FreightBill
    {
        public int ID { get; set; }
        public string Customer { get; set; } 
        public string Display { get; set; }
        public string FreightBillNumber { get; set; } 
        public string FromName { get; set; } 
        public string FromStreet { get; set; } 
        public string FromCity { get; set; } 
        public string FromState { get; set; } 
        public string FromZip { get; set; } 
        public string ToName { get; set; } 
        public string ToStreet { get; set; } 
        public string ToCity { get; set; } 
        public string ToState { get; set; }
        public string ToZip { get; set; } 
        [DataType(DataType.Date)]
        public DateTime? ScheduledDate { get; set; } 
        public string Size { get; set; } 
        public string BranchAndDescription { get; set; }
        public string Unit { get; set; }
        public string PoNumber { get; set; }
        public string DocJob { get; set; }
        public string Comments { get; set; }

        public string Labor1 { get; set; }
        public string Labor2 { get; set; }
        public string Labor3 { get; set; }
        public string Labor4 { get; set; }
        public string Labor5 { get; set; }
        public string Labor6 { get; set; }
        public string Labor7 { get; set; }
        public string Labor8 { get; set; }
        public string Labor9 { get; set; }
        public float Cost1 { get; set; }
        public float Cost2 { get; set; }
        public float Cost3 { get; set; }
        public float Cost4 { get; set; }
        public float Cost5 { get; set; }
        public float Cost6 { get; set; }
        public float Cost7 { get; set; }
        public float Cost8 { get; set; }
        public float Cost9 { get; set; }

        public float Total => Cost1 + Cost2 + Cost3 + Cost4 + Cost5 + Cost6 + Cost7 + Cost8 + Cost9; 


        public string TruckNumber { get; set; } 
        public string Driver { get; set; } 
        public string ReceivedBy { get; set; } 
        [DataType(DataType.Date)]
        public DateTime? CompletionDate { get; set; } 
        // names of receivers 1 and 2 
        public string SiteName { get; set; } 
        public string SiteName2 { get; set; }
        public string SitePhoneNumber { get; set; }
        public string Phone2 { get; set; }
        // 3 and 4 associated with sitename 2
        // if anyone besides me is reading this, big apologies for screwing up not capitalizing "phone3-4"
        public string phone3 { get; set; }
        public string phone4 { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; } 
        public string EmailAddress { get; set; } 
        public string Permit { get; set; }
        public string File2 { get; set; }
        /* FIX "file3" NAME :( and remigrate */
        public string file3 { get; set; }

        public string ToLocation => $"{ToStreet} {ToCity} {ToState} {ToZip}"; 
        public string FromLocation => $"{FromStreet} {FromCity} {FromState} {FromZip}"; 

        public FbStatus Status { get; set; }
        public string CurrentStatus;

        public FreightBill()
        {
            this.Status = FbStatus.Pending;
        }
        
    }
}