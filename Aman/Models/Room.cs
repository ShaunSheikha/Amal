using System;
using System.Collections.Generic;
using System.Text;

namespace Aman.Models
{
    public enum RoomType
    {
        Studio,
        Suite,
        XlSuite,
        Penthouse
    }
    public class Room
    {
        public string ParentHotelID { get; set; }
        public string RoomID { get; set; }
        public decimal Price { get; set; }
        public string FloorPlan { get; set; }
        public string SqFeet { get; set; }
        public DateTime MoveInDate { get; set; }
        public List<LeaseTerm> AvailableLeaseTerms { get; set; }
        public string IconName { get; set; }
        public List<Amenity> Amenities { get; set; }
        public List<string> ImageNames { get; set; }
    }
}
