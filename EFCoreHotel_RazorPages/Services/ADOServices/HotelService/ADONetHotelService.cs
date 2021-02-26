using EFCoreHotel_RazorPages.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreHotel_RazorPages.Services.ADOServices.HotelService
{
    public class ADONetHotelService
    {
        private IConfiguration configuration { get; }
        public ADONetHotelService(IConfiguration config)
        {
            configuration = config;
        }
        public List<Hotel> GetHotels()
        {
            string connectionString = configuration.GetConnectionString("HotelConnection");
            List<Hotel> lst = new List<Hotel>();
            string sql = @"SELECT Hotel.Hotel_No, Hotel.Name, Hotel.Address, COUNT(Room.Room_No) AS RoomCount FROM Hotel JOIN Room ON Hotel.Hotel_No = Room.Hotel_No GROUP BY Hotel.Hotel_No, Hotel.Name, Hotel.Address";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Hotel hotel= new Hotel();
                        hotel.HotelNo = Convert.ToInt32(dataReader[0]);
                        hotel.Name= Convert.ToString(dataReader[1]);
                        hotel.Address = Convert.ToString(dataReader[2]);
                        hotel.RoomCount = Convert.ToInt32(dataReader[3]);
                       lst.Add(hotel);
                    }
                }
            }
            return lst;
        }
    }
}
