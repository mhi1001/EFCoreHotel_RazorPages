using EFCoreHotel_RazorPages.HotelDBContext;
using EFCoreHotel_RazorPages.Models;
using EFCoreHotel_RazorPages.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreHotel_RazorPages.Services.ADOServices.HotelService
{
    public class EFHotelService:IHotelService
    {
        private ADONetHotelService hotelService;
        public EFHotelService(ADONetHotelService service)
        {
           hotelService= service;
        }
        public IEnumerable<Hotel> GetHotels()
        {
            return hotelService.GetHotels();
        }
    }
}
