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
        public string Customer { get; set; } //ok
        public string Display { get; set; }
        public string FreightBillNumber { get; set; } //ok
        public string FromName { get; set; } //ok
        public string FromStreet { get; set; } //ok
        public string FromCity { get; set; } //ok
        public string FromState { get; set; } //ok
        public string FromZip { get; set; } //ok
        public string ToName { get; set; } //ok
        public string ToStreet { get; set; } //ok
        public string ToCity { get; set; } //ok
        public string ToState { get; set; } //ok
        public string ToZip { get; set; } //ok
        [DataType(DataType.Date)]
        public DateTime? ScheduledDate { get; set; } //ok
        public string Size { get; set; } //ok
        public string BranchAndDescription { get; set; } //ok
        public string Unit { get; set; } //ok
        public string PoNumber { get; set; } //ok
        public string DocJob { get; set; } //ok
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

        public float Total => Cost1 + Cost2 + Cost3 + Cost4 + Cost5 + Cost6 + Cost7 + Cost8 + Cost9; //ok


        public string TruckNumber { get; set; } //ok
        public string Driver { get; set; } // ok
        public string ReceivedBy { get; set; } //ok
        [DataType(DataType.Date)]
        public DateTime? CompletionDate { get; set; } //ok
        public string SiteName { get; set; } //ok
        public string SitePhoneNumber { get; set; } //ok
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; } //ok
        public string EmailAddress { get; set; } // ok?
        public string Permit { get; set; }
        public string File2 { get; set; }
        public string file3 { get; set; }

        public string ToLocation => $"{ToStreet} {ToCity} {ToState} {ToZip}"; //ok
        public string FromLocation => $"{FromStreet} {FromCity} {FromState} {FromZip}"; //ok

        public FbStatus Status { get; set; }
        public string CurrentStatus;

        public FreightBill()
        {
            this.Status = FbStatus.Pending;
        }
        
    }
}