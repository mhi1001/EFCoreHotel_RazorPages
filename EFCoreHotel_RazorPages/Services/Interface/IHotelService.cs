using EFCoreHotel_RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreHotel_RazorPages.Services.Interface
{
  public   interface IHotelService
    {
        public IEnumerable<Hotel> GetHotels();
    }
}
