using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreHotel_RazorPages.Models;
using EFCoreHotel_RazorPages.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCoreHotel_RazorPages.Pages.Guests
{
    public class GuestDetailsModel : PageModel
    {
        public IEnumerable<Booking> Bookings { get; set; }
        private IBookingService bookingService;
        public GuestDetailsModel(IBookingService service)
        {
            bookingService = service;
        }

        public IActionResult OnGet(int guestNo)
        {
            Bookings = bookingService.GetBookingsByGuestNo(guestNo);
            return Page();
        }
    }
}
