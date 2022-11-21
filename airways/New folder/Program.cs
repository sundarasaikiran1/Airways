using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using flightentity;
using Login_entity;
using AirwaysBussinessLayerLIb;
using CreditCardLib;
using AdminLb;
using System.Data.SqlClient;

namespace AirwaysConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\t\t ********************************************************************");
            Console.WriteLine("\n\t\t                   WELCOME TO FLAMINGO AIRLINE SYSTEM                ");
            Console.WriteLine("\n\t\t ********************************************************************");
            Console.WriteLine(" Please enter your choice from below (1-3)  :");
            Console.WriteLine("1. NewUser...........");
            Console.WriteLine("2. Login.............");
            Console.WriteLine("3. Admin login...........");
            bool st = false;
            Console.WriteLine("Enter Choice :");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 3)
            {
                Admin a= new Admin();
                Console.WriteLine("Enter AdminId");
                a.AdminId= Console.ReadLine();
                Console.WriteLine("Enter AdminPassword");
                a.AdminPassword= Console.ReadLine();
                Console.WriteLine("Enter DepartmentId");
                a.depID= Console.ReadLine();
                AdminVerify(a);
            }
            
            
            
            else if (choice == 1)
            {
                if (AddUser())
                {
                    st=true;
                    Console.WriteLine("Record Inserted");
                }
                
            } else if (choice == 2)
            {
                if (Userlogin())
                {
                    st= true;
                    Console.WriteLine("Login Successful.........");
                }
                else
                {
                    Console.WriteLine("wrong password");
                    st=false;
                }
            }
            else
            {
                Console.WriteLine("enter correct choice");
            }
            if (st == true)
            {
                bool k = true;
                while (k)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("1.Flight Booking...");
                    Console.WriteLine("2.Cancel Tickets....");
                    Console.WriteLine("3.Booking Status....");
                    Console.WriteLine("4.Exit");
                    Console.WriteLine("\n");
                    Console.WriteLine("Enter choice");
                    
                    int p=Convert.ToInt32(Console.ReadLine());
                    if (p == 1)
                    {
                        
                        Booking();
                    }
                    else if (p == 2)
                    {
                        CancelTicket();
                    }
                    else if(p== 3)
                    {
                        BookingStatus();
                    }else if (p == 4)
                    {
                        k = false;
                    }
                    else
                    {
                        Console.WriteLine("Enter corect choice");
                    }
                }
            }

        }
        public static void AdminVerify(Admin k)
        {
            SqlConnection cne = new SqlConnection("Data Source=LAPTOP-L67T7EHI;Initial Catalog=Flamingo_Airways;Integrated Security=True");
            SqlCommand cmde = new SqlCommand("VerifyAdmin", cne);
            cmde.Parameters.AddWithValue("@AdminId",k.AdminId);
            cmde.Parameters.AddWithValue("@AdminPassword",k.AdminPassword);
            cmde.CommandType = System.Data.CommandType.StoredProcedure;
            cne.Open();
            SqlDataReader sdr = cmde.ExecuteReader();
            while(sdr.Read())
            {
                Console.WriteLine("login success.......");
                Console.WriteLine();
                Console.WriteLine("enter choice ");
                
                
                bool p = true;
                while (p)
                {
                    Console.WriteLine("1. Update Flight Details......");
                    Console.WriteLine("2. Exit.");
                    Console.WriteLine("Enter choice");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {
                        AirwaysBussinessLayer A = new AirwaysBussinessLayer();
                        A.ChangeTimings();
                    }
                    else if (choice == 2)
                    {
                        p=false;
                    }
                    else
                    {
                        Console.WriteLine("Enter correct choice..");
                    }
                }
            }
            sdr.Close();
            
        }
        public static bool AddUser()
        {
            try
            {
                Login k = new Login();
                Console.WriteLine("Enter PassportNO ");
                k.PassportNo = Console.ReadLine();
                if (k.PassportNo.Length!=9)
                {
                    throw new Exception("Passport contains 9 characters");
                }
                Console.WriteLine("Enter Name..");
                k.Name = Console.ReadLine();
                Console.WriteLine("Enter Email");
                k.email = Console.ReadLine();
                Console.WriteLine("Enter Password contain minimum 8 characters...");
                k.password = Console.ReadLine();
                AirwaysBussinessLayer Ab = new AirwaysBussinessLayer();
                if (k.password.Length < 8)
                {
                    throw new Exception("Password contain minimum 8 characters");
                }
                return Ab.AddUser(k);
            }catch (Exception e)
            {
                throw;
            }

            
        }
        public static bool Userlogin()
        {
            Login k = new Login();
            Console.WriteLine("Enter PassportNo");
            k.PassportNo=Console.ReadLine();
            Console.WriteLine("Enter Password");
            k.password=Console.ReadLine();
            AirwaysBussinessLayer A = new AirwaysBussinessLayer();

            return A.UserLogin(k);
            
        }
        public static void Booking()
        {
            try
            {
                flight k = new flight();
                Console.WriteLine("Available cities");
                Console.WriteLine(" Delhi\n Chennai\n Hyderabad\n Mumbai\n Pune\n Kolkata\n ");
                Console.WriteLine("Enter from address");
                k.origin = Console.ReadLine();
                if (k.origin == "Delhi" || k.origin == "Chennai" || k.origin == "Hyderabad" || k.origin == "Mumbai" || k.origin == "Pune" || k.origin == "Kolkata")
                {
                    
                }
                else
                {
                    throw new Exception("Above 6 states are available...");
                }
                Console.WriteLine("Enter Destination address");
                k.Destination = Console.ReadLine();
                if (k.Destination== "Delhi" || k.Destination== "Chennai" || k.Destination== "Hyderabad" || k.Destination== "Mumbai" || k.Destination== "Pune" || k.Destination == "Kolkata")
                {
                    
                }
                else
                {
                    throw new Exception("Above 6 states are available...");
                }
                AirwaysBussinessLayer A = new AirwaysBussinessLayer();
                A.Booking(k);
            }
            catch (Exception ex)
            {
                throw;
            }
            
            
        }
        public static void CancelTicket()
        {
            Console.WriteLine("Enter PNR NUmber To Cancel Ticket");
            string PN = Console.ReadLine();
            AirwaysBussinessLayer A = new AirwaysBussinessLayer();
            A.CancelTickets(PN);
        }
        public static void BookingStatus()
        {
            Console.WriteLine("Enter PNRNumber..");
            string pn= Console.ReadLine();
            AirwaysBussinessLayer A = new AirwaysBussinessLayer();
            A.BookingStatus(pn);
        }
    }
}
