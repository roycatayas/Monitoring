using System;

namespace DashBoard.Web.Models
{
    public class Transaction
    {
        public int TransactionNo { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string RFIDCardNumber { get; set; }
        public string ControllerID { get; set; }
        public string DoorNumber { get; set; }
        public string EventAlarmCode { get; set; }
        public string TransactionType { get; set; }
        public string CardReaderName { get; set; }
        public string TransactionDescription { get; set; }
        public string TransactionDate { get; set; }
    }
}
