using EFCoreHotel_RazorPages.HotelDBContext;
using EFCoreHotel_RazorPages.Models;
using EFCoreHotel_RazorPages.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreHotel_RazorPages.Services.ADOServices.RoomService
{
    public class EFRoomService : IRoomService
    {
        private ADONetRoomService  roomService;
        public EFRoomService(ADONetRoomService service)
        {
            roomService = service;
        }
        public IEnumerable<Room> GetRooms()
        {
            return roomService.GetRooms();
        }

        public IEnumerable<Room> FilterRoomsByTypePrice(string type, double price)
        {
            return roomService.FilterRoomsByTypePrice(type, price);
        }

        public IEnumerable<Room> GetRoomByHotelNo(int hotelno)
        {
            return roomService.GetRoomByHotelNo(hotelno);
        }
    }
}
