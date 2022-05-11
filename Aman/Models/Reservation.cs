using System;
using System.Collections.Generic;
using System.Text;

namespace Aman.Models
{
    public class Reservation
    {
        public string ReservationId { get; set; }
        public string ReservationType { get; set; }
        public string ReservationTypeIcon { get; set; }
        public string Name { get; set; }
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
        public string Address { get; set; }
        public string RoomType { get; set; }
        public LeaseTerm LeaseTerm { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Time { get; set; }
        public string PaymentType { get; set; }
    }
}
