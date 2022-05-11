using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace Aman.Models
{
    public class Hotel
    {
        //Capital "ID"
        public string HotelID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string CityStateZip { get; set; }
        public List<Room> AvailableRooms { get; set; }
        public List<Amenity> Amentities { get; set; }
        public List<string> ImageNames { get; set; }
        public Position HotelPosition { get; set; }
        public string ThumbnailName { get; set; }
        public string AvailableRoomsList { get; set; }
    }
}
