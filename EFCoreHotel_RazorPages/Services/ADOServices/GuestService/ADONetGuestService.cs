using EFCoreHotel_RazorPages.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreHotel_RazorPages.Services.ADOServices.GuestService
{
    public class ADONetGuestService
    {
        private IConfiguration configuration { get; }
        public ADONetGuestService(IConfiguration config)
        {
            configuration = config;
        }
        public List<Guest> GetGuests()
        {
            string connectionString = configuration.GetConnectionString("HotelConnection");
            List<Guest> lst = new List<Guest>();
            string sql = "Select * From Guest ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Guest guest = new Guest();
                        guest.GuestNo = Convert.ToInt32(dataReader[0]);
                        guest.Name = Convert.ToString(dataReader[1]);
                        guest.Address = Convert.ToString(dataReader[2]);

                        lst.Add(guest);
                    }
                }
            }
            return lst;
        }

        public List<Guest> FilterGuestsByAddress(string searchCriteria)
        {
            string connectionString = configuration.GetConnectionString("HotelConnection");
            List<Guest> lst = new List<Guest>(); //Filtered results get added to this list and then it is returned by the method


            //string sql = "SELECT * FROM Guest WHERE Address LIKE '%' + @searchCriteria + '%' ";
            string sql = "SELECT * FROM Guest WHERE (SELECT RIGHT(Address, CHARINDEX(' ', REVERSE(Address)) - 1)) LIKE '%' + @searchCriteria + '%' ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@searchCriteria", searchCriteria);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read()) // while I am reading row by row
                    {
                        Guest guest = new Guest();
                        guest.GuestNo = Convert.ToInt32(dataReader[0]);
                        guest.Name = Convert.ToString(dataReader[1]);
                        guest.Address = Convert.ToString(dataReader[2]);
                        lst.Add(guest);

                    }
                }
            }
            return lst;
        }
        public List<Guest> GetSpecificGuests(string hotelName, DateTime date)
        {
            string connectionString = configuration.GetConnectionString("HotelConnection");
            List<Guest> lst = new List<Guest>(); //Filtered results get added to this list and then it is returned by the method
            

            string sql = @"SELECT Guest.Name, Guest.Address, Guest.Guest_No 
                            FROM Guest, Booking, Hotel 
                            where Guest.Guest_No = Booking.Guest_No 
                            AND Booking.Hotel_No = Hotel.Hotel_No
                            AND Hotel.Name = @hotelName
                            AND Booking.Date_From <= @date 
                            AND Booking.Date_To >= @date";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@hotelName", hotelName);
                command.Parameters.AddWithValue("@date", date);
                
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read()) // while I am reading row by row
                    {
                        Guest guest = new Guest();
                        guest.Name = Convert.ToString(dataReader[0]);
                        guest.Address = Convert.ToString(dataReader[1]);
                        guest.GuestNo = Convert.ToInt32(dataReader[2]);
                        lst.Add(guest);

                    }
                }
            }
            return lst;
        }
    }
}
