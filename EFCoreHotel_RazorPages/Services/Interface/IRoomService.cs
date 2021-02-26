using EFCoreHotel_RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreHotel_RazorPages.Services.Interface
{
  public  interface IRoomService
    {
        public IEnumerable<Room> GetRooms();

        public IEnumerable<Room> FilterRoomsByTypePrice(string type, double price);

        public IEnumerable<Room> GetRoomByHotelNo(int hotelno);
    }
}
