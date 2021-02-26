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
    public class HotelDetails_RoomInfoModel : PageModel
    {
        
        public IEnumerable<Booking> Bookings { get; set; }
        private IBookingService bookingService;

        public HotelDetails_RoomInfoModel(IBookingService service)
        {
            bookingService = service;
        }

        public void OnGet(int roomid)
        {
            Bookings = bookingService.GetBookingInfo(roomid);
        }
    }
}
