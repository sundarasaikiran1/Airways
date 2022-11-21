using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using flightentity;
using Login_entity;
using AirwaysDataAcessLayer;
using CreditCardLib;

namespace AirwaysBussinessLayerLIb
{
    public class AirwaysBussinessLayer
    {
        public bool AddUser(Login k)
        {
            AirwaysDataAs a=new AirwaysDataAs();
            return a.AddUser(k);
        }
        public bool UserLogin(Login k)
        {
            AirwaysDataAs a = new AirwaysDataAs();

            return a.UserLogin(k);
        }
        public void Booking(flight k)
        {
            AirwaysDataAs a = new AirwaysDataAs();
            a.Booking(k);
            
        }
        public void CancelTickets(string PN)
        {
            AirwaysDataAs a = new AirwaysDataAs();

            a.CancelTickets(PN);
        }
        public void BookingStatus(string PN)
        {
            AirwaysDataAs a = new AirwaysDataAs();

            a.BookingStatus(PN);
        }
        
        public void ChangeTimings()
        {
            AirwaysDataAs a = new AirwaysDataAs();
            a.ChangeTimings();
        }
    }
}
