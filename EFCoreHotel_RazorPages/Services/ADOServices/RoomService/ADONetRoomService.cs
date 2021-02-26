using EFCoreHotel_RazorPages.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreHotel_RazorPages.Services.ADOServices.RoomService
{
    public class ADONetRoomService
    {
        private IConfiguration configuration { get; }
        public ADONetRoomService(IConfiguration config)
        {
            configuration = config;
        }
        public List<Room> GetRooms()
        {
            string connectionString = configuration.GetConnectionString("HotelConnection");
            List<Room> lst = new List<Room>();
            string sql = "Select * From Room ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Room room = new Room();
                       room.RoomNo= Convert.ToInt32(dataReader[0]);
                        room.HotelNo = Convert.ToInt32(dataReader[1]);
                       room.Types = Convert.ToString(dataReader[2]);
                        room.Price = Convert.ToDouble(dataReader[3]);
                        lst.Add(room);
                    }
                }
            }
            return lst;
        }
        
        public List<Room> FilterRoomsByTypePrice(string type, double price)
        {
            string connectionString = configuration.GetConnectionString("HotelConnection");
            List<Room> lst = new List<Room>(); //Filtered results get added to this list and then it is returned by the method

            string sql = @"SELECT * FROM Room WHERE Types=@type AND Price < @price";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@type",type);
                command.Parameters.AddWithValue("@price",price);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read()) // while I am reading row by row
                    {
                        Room room = new Room();
                        room.RoomNo= Convert.ToInt32(dataReader[0]);
                        room.HotelNo = Convert.ToInt32(dataReader[1]);
                        room.Types = Convert.ToString(dataReader[2]);
                        room.Price = Convert.ToDouble(dataReader[3]);
                        lst.Add(room);
                        
                    }
                }
            }
            return lst;
        }
        //To-Do
        //select Room_No, Types, Price from Room inner join Hotel on Room.Hotel_No = Hotel.Hotel_No order by Name
        public List<Room> GetRoomByHotelNo(int hotelno)
        {
            string connectionString = configuration.GetConnectionString("HotelConnection");
            List<Room> lst = new List<Room>(); //Filtered results get added to this list and then it is returned by the method

            string sql = @"SELECT * FROM Room where Hotel_No = @hotelno";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@hotelno",hotelno);
                
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read()) // while I am reading row by row
                    {
                        Room room = new Room();
                        room.RoomNo= Convert.ToInt32(dataReader[0]);
                        room.HotelNo = Convert.ToInt32(dataReader[1]);
                        room.Types = Convert.ToString(dataReader[2]);
                        room.Price = Convert.ToDouble(dataReader[3]);
                        lst.Add(room);
                        
                    }
                }
            }
            return lst;
        }
    }
}
