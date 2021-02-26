using EFCoreHotel_RazorPages.HotelDBContext;
using EFCoreHotel_RazorPages.Models;
using EFCoreHotel_RazorPages.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreHotel_RazorPages.Services.ADOServices.GuestService
{
    public class EFGuestService:IGuestService
    {
        private ADONetGuestService guestService;
        public EFGuestService(ADONetGuestService service)
        {
           guestService= service;
        }
        public IEnumerable<Guest> GetGuests()
        {
            return guestService.GetGuests();
        }

        public IEnumerable<Guest> FilterGuestsByAddress(string searchCriteria)
        {
            return guestService.FilterGuestsByAddress(searchCriteria);
        }

        public IEnumerable<Guest> GetSpecificGuests(string hotelName, DateTime date)
        {
            return guestService.GetSpecificGuests(hotelName, date);
        }

    }
}
