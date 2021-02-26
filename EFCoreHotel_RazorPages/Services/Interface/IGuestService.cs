using EFCoreHotel_RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreHotel_RazorPages.Services.Interface
{
    public interface IGuestService
    {
        public IEnumerable<Guest> GetGuests();

        public IEnumerable<Guest> FilterGuestsByAddress(string searchCriteria);

        IEnumerable<Guest> GetSpecificGuests(string hotelName, DateTime date);
    }
}
