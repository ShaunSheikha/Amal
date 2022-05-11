using Aman.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace Aman.ViewModels
{
    public class CustomPin: Pin
    {
        public string PinId { get; set; }
        public List<Room> AvailableRooms { get; set; }
        public CustomPin()
        {

        }
    }
}
