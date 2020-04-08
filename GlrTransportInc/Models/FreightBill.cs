using System;

namespace GlrTransportInc.Models
{
    public enum FbStatus
    {
        Pending,
        Completed,
        Canceled
    }

    public class FreightBill
    {
        public int ID { get; set; }
        private string FreightBillNumber { get; set; }
        public string Customer { get; set; }
        public string Driver { get; set; }

        public DateTime Date { get; set; }

        public string FromLocation { get; set; }
        public string PoNumber { get; set; }
        public string TruckNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string ToZip { get; set; }
        public string ToState { get; set; }
        public string ToStreet { get; set; }
        public string ToCity { get; set; }

        public string ToLocation => $"{ToStreet} {ToCity} {ToState} {ToZip}";

        public FbStatus Status { get; set; }
        public string CurrentStatus;

        public FreightBill()
        {
            this.Status = FbStatus.Pending;
        }
        
    }
}