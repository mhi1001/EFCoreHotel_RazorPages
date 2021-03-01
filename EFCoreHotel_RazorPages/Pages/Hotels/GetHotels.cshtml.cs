using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EFCoreHotel_RazorPages.HotelDBContext;
using EFCoreHotel_RazorPages.Models;
using EFCoreHotel_RazorPages.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Query;

namespace EFCoreHotel_RazorPages
{
    public class GetHotelsModel : PageModel
    {
        public int Bookings { get; set; }
        [BindProperty(SupportsGet = true)]
        [Required]
        public String HotelName { get; set; }
        [Required]
        [BindProperty(SupportsGet = true)]
        public DateTime DateTime { get; set; }
        public double Income { get; set; }
        public IEnumerable<Hotel> Hotels { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        IHotelService hotelService;
        private IBookingService bookingService;
        public GetHotelsModel(IHotelService service, IBookingService service1)
        {
            hotelService = service;
            bookingService = service1;

        }
        public void OnGet()
        {
            Hotels = hotelService.GetHotels();

            if (ModelState.IsValid)
            {
                Income = hotelService.GetSpecificDayIncome(HotelName, DateTime);
            }
        }

        public void OnPostPrindsen()
        {
            Hotels = hotelService.GetHotels();
            Bookings = bookingService.GetBookinsPerHotel();
        }
    }
}