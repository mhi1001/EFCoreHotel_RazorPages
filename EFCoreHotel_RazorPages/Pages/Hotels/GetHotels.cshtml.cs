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

namespace EFCoreHotel_RazorPages
{
    public class GetHotelsModel : PageModel
    {
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
       
        public GetHotelsModel(IHotelService service)
        {
            hotelService = service;
            
        }
        public void OnGet()
        {
            Hotels = hotelService.GetHotels();

            if (ModelState.IsValid)
            {
                Income = hotelService.GetSpecificDayIncome(HotelName, DateTime);
            }
        }
    }
}