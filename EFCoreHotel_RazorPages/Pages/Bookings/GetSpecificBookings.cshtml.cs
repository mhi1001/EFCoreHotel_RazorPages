using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EFCoreHotel_RazorPages.Models;
using EFCoreHotel_RazorPages.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EFCoreHotel_RazorPages.Pages.Bookings
{
    public class GetSpecificBookingsModel : PageModel
    {
        public IEnumerable<Guest> Guests { get; set; }

        [BindProperty(SupportsGet = true)]
        [Required]
        public string HotelName { get; set; }

        [Required]
        [BindProperty(SupportsGet = true)]
        public DateTime DateTime { get; set; }


        private IGuestService guestService;

        public GetSpecificBookingsModel(IGuestService service)
        {
            guestService = service;
        }

        public void OnGet()
        {
            
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Guests = guestService.GetSpecificGuests(HotelName, DateTime);
            }
        }
    }
}
