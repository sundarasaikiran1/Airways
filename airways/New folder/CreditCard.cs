using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardLib
{
    public class CreditCard
    {
        public string flightId { get; set; }
        public string PassportNo { get; set; }
        public long CardNo  { get; set; }
        public string ExpDate { get; set; }
        public int CVV { get; set; }
        public int TotalTickets { get; set; }
        public int Total_Amount { get; set; }
        public string PNRno  { get; set; }
    }
}
