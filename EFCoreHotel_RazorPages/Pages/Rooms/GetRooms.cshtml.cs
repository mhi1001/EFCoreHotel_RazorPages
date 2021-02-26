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
    public class GetRoomsModel : PageModel
    {
        public IEnumerable<Room> Rooms { get; set; }

        [BindProperty(SupportsGet = true)]
        [Required(ErrorMessage = "This field is mandatory")]
        [StringLength(1, ErrorMessage = "Type only takes 1 letter")]
        public string Type { get; set; }

        [BindProperty(SupportsGet = true)]
        [Required(ErrorMessage = "This field is mandatory")]
        public double Price { get; set; }
        

        IRoomService roomService;
        public GetRoomsModel(IRoomService service)
        {
            roomService = service;
        }
        public void OnGet()
        {
            if (string.IsNullOrEmpty(Type))
            {
                Rooms = roomService.GetRooms();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    Rooms = roomService.FilterRoomsByTypePrice(Type, Price);
                }
                
            }
        }

    }
}