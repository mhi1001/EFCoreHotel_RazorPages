using EFCoreHotel_RazorPages.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreHotel_RazorPages.Services.ADOServices.BookingService
{
    public class ADONetBookingService
    {
        private IConfiguration configuration { get; }
        public ADONetBookingService(IConfiguration config)
        {
            configuration = config;
        }
        public List<Booking> GetBookings()
        {
            string connectionString = configuration.GetConnectionString("HotelConnection");
            List<Booking> lst = new List<Booking>();
            string sql = "Select * From Booking ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Booking booking = new Booking();
                        booking.BookingId = Convert.ToInt32(dataReader[0]);
                        booking.HotelNo = Convert.ToInt32(dataReader[1]);
                        booking.GuestNo = Convert.ToInt32(dataReader[2]);
                        booking.DateFrom = Convert.ToDateTime(dataReader[3]);
                        booking.DateTo = Convert.ToDateTime(dataReader[4]);
                        booking.RoomNo = Convert.ToInt32(dataReader[5]);
                        lst.Add(booking);
                    }
                }
            }
            return lst;
        }
        //todo
        //SELECT Booking.Guest_No, Hotel_No, Date_From, Date_From, Room_No, Booking_id FROM Booking INNER JOIN Guest ON Booking.Guest_No = 1;
        public List<Booking> GetBookingsByGuestNo(int guestNo)
        {
            string connectionString = configuration.GetConnectionString("HotelConnection");
            List<Booking> lst = new List<Booking>();
            string sql = @"SELECT * from Booking where Booking.Guest_No = @guestNo;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@guestNo",guestNo);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Booking booking = new Booking();
                        booking.BookingId = Convert.ToInt32(dataReader[0]);
                        booking.HotelNo = Convert.ToInt32(dataReader[1]);
                        booking.GuestNo = Convert.ToInt32(dataReader[2]);
                        booking.DateFrom = Convert.ToDateTime(dataReader[3]);
                        booking.DateTo = Convert.ToDateTime(dataReader[4]);
                        booking.RoomNo = Convert.ToInt32(dataReader[5]);
                        lst.Add(booking);
                    }
                }
            }
            return lst;
        }
        public List<Booking> GetBookingInfo(int roomid)
        {
            string connectionString = configuration.GetConnectionString("HotelConnection");
            List<Booking> lst = new List<Booking>();
            string sql = @"select Booking.Booking_id, Booking.Date_From, Booking.Date_To, Guest.Name, Guest.Address FROM Booking INNER JOIN Guest ON Booking.Guest_No = Guest.Guest_No where Booking.Room_No = @roomid;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@roomid",roomid);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Booking booking = new Booking();
                        booking.Guest = new Guest();
                        booking.BookingId = Convert.ToInt32(dataReader[0]);
                        booking.DateFrom = Convert.ToDateTime(dataReader[1]);
                        booking.DateTo = Convert.ToDateTime(dataReader[2]);
                        booking.Guest.Name = Convert.ToString(dataReader[3]);
                        booking.Guest.Address = Convert.ToString(dataReader[4]);
                        lst.Add(booking);
                    }
                }
            }
            return lst;
        }

    }
}
