using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreHotel_RazorPages.Models;
using EFCoreHotel_RazorPages.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCoreHotel_RazorPages.Pages.Hotels
{
    public class HotelDetailsModel : PageModel
    {
        public IEnumerable<Room> Rooms { get; set; }
        [BindProperty]
        public string HotelName { get; set; }
        public int RoomCount { get; set; }
        IRoomService roomService;
        public HotelDetailsModel(IRoomService service)
        {
            roomService= service;
        }
        public IActionResult OnGet(int hotelNo, string hotelName, int roomCount)
        {
            Rooms = roomService.GetRoomByHotelNo(hotelNo);
            HotelName = hotelName;//Spagueti way to get the hotel name and room count
            RoomCount = roomCount;

            return Page();
        }
    }
}
