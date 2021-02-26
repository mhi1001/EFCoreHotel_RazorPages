using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreHotel_RazorPages.HotelDBContext;
using EFCoreHotel_RazorPages.Models;
using EFCoreHotel_RazorPages.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCoreHotel_RazorPages
{
    public class GetBookingsModel : PageModel
    {
        public IEnumerable<Booking> Bookings { get; set; }
     
        IBookingService bookingService;
        public GetBookingsModel(IBookingService service)
        {
            bookingService= service;
        }
        public void OnGet()
        {
           Bookings= bookingService.GetBookings();
        }
    }
}