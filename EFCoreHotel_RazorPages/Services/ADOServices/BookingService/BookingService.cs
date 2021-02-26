using EFCoreHotel_RazorPages.HotelDBContext;
using EFCoreHotel_RazorPages.Models;
using EFCoreHotel_RazorPages.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreHotel_RazorPages.Services.ADOServices.BookingService
{
    public class EFBookingService:IBookingService
    {
        private ADONetBookingService bookingService;
        public EFBookingService(ADONetBookingService service)
        {
           bookingService= service;
        }

        public IEnumerable<Booking> GetBookings()
        {
            return bookingService.GetBookings();
        }

        public IEnumerable<Booking> GetBookingsByGuestNo(int guestNo)
        {
            return bookingService.GetBookingsByGuestNo(guestNo);
        }

        public IEnumerable<Booking> GetBookingInfo(int roomid)
        {
            return bookingService.GetBookingInfo(roomid);
        }
    }
}
