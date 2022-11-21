using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using flightentity;
using Login_entity;
using System.Data;
using CreditCardLib;

namespace AirwaysDataAcessLayer
{
    public class AirwaysDataAs
    {
        public  static string PNRnO()
        {
            Random r = new Random();
            
            int k = r.Next();
            return "FLM"+k ;
        }
        public bool AddUser(Login k)
        {
            bool status = true;
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=LAPTOP-L67T7EHI;Initial Catalog=Flamingo_Airways;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("AddNewUser", cn);
                cmd.Parameters.AddWithValue("@PassportNO", k.PassportNo);
                cmd.Parameters.AddWithValue("@Name", k.Name);
                cmd.Parameters.AddWithValue("@emailId", k.email);
                cmd.Parameters.AddWithValue("@Passwd", k.password);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i ==0)
                {
                    status = false;
                    throw new Exception("Could not insert record");
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            
            return status;
        }
        public bool UserLogin(Login k)
        {
            bool status = true;
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=LAPTOP-L67T7EHI;Initial Catalog=Flamingo_Airways;Integrated Security=True");
                cn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter adap = new SqlDataAdapter("Select PassportNo,Passwd from loginData where PassportNo='" + k.PassportNo + "' AND Passwd='" + k.password + "'", cn);
                adap.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                if (count == 0)
                {
                    throw new Exception("No PassportNO in record ,Login Failed....");
                    status=false;
                }

            }catch (Exception ex)
            {
                throw;
            }
            return status;
            
        }
        public void Booking(flight k)
        {
            
            string flightId="";
            string origin;
            string Destination;
            string DateOfTravel;
            string TravelTime;
            string distance;
            int price=0;
            int AvailbleSeats;
            

            SqlConnection cn = new SqlConnection("Data Source=LAPTOP-L67T7EHI;Initial Catalog=Flamingo_Airways;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("flightBooking", cn);

            
            cmd.Parameters.AddWithValue("@origin", k.origin);
            cmd.Parameters.AddWithValue("@Destination", k.Destination);
            cmd.CommandType=CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader sdr=cmd.ExecuteReader();
            
            while (sdr.Read())
            {
                
                flightId = sdr[0].ToString();
                origin = sdr[1].ToString();
                Destination = sdr[2].ToString();
                DateOfTravel = sdr[3].ToString();
                TravelTime = sdr[4].ToString();
                distance = sdr[5].ToString();
                price = (int)sdr[6];
                AvailbleSeats = (int)sdr[7];
                Console.WriteLine("Flight No : " + flightId);
                Console.WriteLine("From : " + origin);
                Console.WriteLine("Destination : " + Destination);
                Console.WriteLine("DateOfTravel : " + DateOfTravel);
                Console.WriteLine("Travel Time : " + TravelTime);
                Console.WriteLine("Distance B/W : " + distance);
                Console.WriteLine("Price : " + price);
                Console.WriteLine("Availble Seats : " + AvailbleSeats);

               
            }  
            sdr.Close();
            Console.WriteLine("Enter How many tickets......");
            int pk = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Total cost......");
            Console.WriteLine(pk*price);
            int h=pk*price;
            string m = DebitCard(flightId, pk, h);
            if (m!=null)
            {
                Console.WriteLine(flightId);
                SqlConnection cne = new SqlConnection("Data Source=LAPTOP-L67T7EHI;Initial Catalog=Flamingo_Airways;Integrated Security=True");
                SqlCommand cmde = new SqlCommand("Total_seats", cne);
                cmde.Parameters.AddWithValue("@flightId",flightId);
                cmde.Parameters.AddWithValue("@pt", pk);
                cmde.CommandType = System.Data.CommandType.StoredProcedure;
                cne.Open();
                int i = cmde.ExecuteNonQuery();
                if (i >= 1)
                {
                    Console.WriteLine("Tickets Booked.......");
                    Console.WriteLine("Your PNRno  : " + m);
                }
                cne.Close();

            }
            else
            {
                Console.WriteLine("Tickets Not booked...........");
            }

            
        }
        public void CancelTickets(string Pnr)
        {
            string flightId;
            int Total_Amount;
            int Total_Tickets;
            SqlConnection cn = new SqlConnection("Data Source=LAPTOP-L67T7EHI;Initial Catalog=Flamingo_Airways;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Refund", cn);
            cmd.Parameters.AddWithValue("@PNRno", Pnr);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader sdr=cmd.ExecuteReader();
            
            if (sdr.Read())
            {
                flightId = sdr[0].ToString();
                Total_Amount = (int)sdr[1];
                Total_Tickets= (int)sdr[2];
                Console.WriteLine("Total amount :" + Total_Amount);
                double k = Total_Amount*0.70;
                Console.WriteLine("Refund Amount : "+k);
                TicketsUpdate(Total_Tickets, Pnr,flightId);





            }
            sdr.Close();
            cn.Close();


            cn.Open();
            
            
            SqlCommand cmds = new SqlCommand("CancelTicket", cn);
            cmds.Parameters.AddWithValue("@PNRno", Pnr);
            cmds.CommandType = CommandType.StoredProcedure;
            
            int l = cmds.ExecuteNonQuery();
            if (l >= 1)
            {
                Console.WriteLine("Tickets Cancelled...");
            }
          
        
            cn.Close();

        }
        public void BookingStatus(string Pnr)
        {
            SqlConnection cn = new SqlConnection("Data Source=LAPTOP-L67T7EHI;Initial Catalog=Flamingo_Airways;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("BookingStatus", cn);
            cmd.Parameters.AddWithValue("@PNRno",Pnr);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            string flightId = "";
            string PassportNO;
            int Total_Tickets;
            int Total_Amount;

            while (sdr.Read())
            {
                flightId = sdr[0].ToString();
                PassportNO=sdr[1].ToString();
                Total_Tickets = (int)sdr[2];
                Total_Amount = (int)sdr[3];
                Console.WriteLine("Flight No : " + flightId);
                Console.WriteLine("PassportNO : " + PassportNO);
                Console.WriteLine("Total_Tickets : " + Total_Tickets);
                Console.WriteLine("Total_Amount : "+Total_Amount);
                Console.WriteLine("Booking Done..");

            }
            sdr.Close();
            cn.Close();













        }
        public static string DebitCard(string FlightId,int totalTk,int money)
        {
            bool status = false;
            string pp;
            try
            {
                Console.WriteLine("Enter Card Number" );
                string card = Console.ReadLine();
                if (card.Length==0 || card.Length > 12)
                {
                    throw new Exception("card number contain 10 digits");
                }
                Console.WriteLine("Card valid Date  MM/YY");
                String exp = Console.ReadLine();
                Console.WriteLine("Enter CVV last three digits on the back of your card");
                int cvv = Convert.ToInt32(Console.ReadLine());
                if(cvv<100 && cvv > 999)
                {
                    throw new Exception("CVV number contain last three digit of card Number");
                }
                Console.WriteLine("enter PassportNo");
                string Pasport = (Console.ReadLine());
                pp = PNRnO();
                SqlConnection cn = new SqlConnection("Data Source=LAPTOP-L67T7EHI;Initial Catalog=Flamingo_Airways;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("CreditCardDetails", cn);

                cmd.Parameters.AddWithValue("@flightId", FlightId);
                cmd.Parameters.AddWithValue("@PassportNO", Pasport);
                cmd.Parameters.AddWithValue("@Cardnumber", card);
                cmd.Parameters.AddWithValue("@expDate", exp);
                cmd.Parameters.AddWithValue("@CVV", cvv);
                cmd.Parameters.AddWithValue("@Total_tickets", totalTk);
                cmd.Parameters.AddWithValue("@Total_Amount", money);
                cmd.Parameters.AddWithValue("@PNRno", pp);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i==0)
                {
                    throw new Exception("Record Not inserted");
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            return pp;
        }
        public static void TicketsUpdate(int Total_Tickets,string Pnr,string flightId)
        {
            SqlConnection cn = new SqlConnection("Data Source=LAPTOP-L67T7EHI;Initial Catalog=Flamingo_Airways;Integrated Security=True");
            Console.WriteLine("Total_Tickets" + Total_Tickets);
            SqlCommand cmdp = new SqlCommand("UpdateCancelTickets", cn);
            cmdp.Parameters.AddWithValue("@flightId",flightId);
            cmdp.Parameters.AddWithValue("@UPT", Total_Tickets);
            cmdp.CommandType = CommandType.StoredProcedure;
            cn.Open();
            int i = cmdp.ExecuteNonQuery();
            if (i >= 1)
            {
                Console.WriteLine("Tickets Updated.......");

            }
            cn.Close();
        }


        
        public  void ChangeTimings()
        {
            SqlConnection cne = new SqlConnection("Data Source=LAPTOP-L67T7EHI;Initial Catalog=Flamingo_Airways;Integrated Security=True");
            SqlCommand cmde = new SqlCommand("Change_flight_details", cne);
            Console.WriteLine("enter flight Id to Change");
            string flightId=Console.ReadLine();
            Console.WriteLine("Enter Time to change..");
            string Time=Console.ReadLine();
            Console.WriteLine("Enter price to change..");
            int price = Convert.ToInt32(Console.ReadLine());
            cmde.Parameters.AddWithValue("@flightId", flightId);
            cmde.Parameters.AddWithValue("@TravelTime",Time);
            cmde.Parameters.AddWithValue("@price", price);
            cmde.CommandType = System.Data.CommandType.StoredProcedure;
            cne.Open();
            int i = cmde.ExecuteNonQuery();
            if (i >= 1)
            {
                Console.WriteLine("Flight details Updated.......");
                
            }
            cne.Close();
        }
    }
}
