using Aman.Models;
using Aman.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Aman.ViewModels
{
    [QueryProperty(nameof(ParentHotelId), nameof(ParentHotelId))]
    [QueryProperty(nameof(RoomId), nameof(RoomId))]
    class RequestTourViewModel: BaseViewModel
    {
        private string _parentHotelId;
        private string _roomId;
        private string _name;
        private string _address;
        private string _city;
        private string _state;
        private string _zipcode;
        private string _country;
        private string _sqFeet;
        private string _userFirstName;
        private string _userLastName;
        private string _userEmail;
        private string _userPhoneNumber;
        private DateTime _tourDate;
        private TimeSpan _tourTime;
        private string _comments;


        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
        public string ParentHotelId
        {
            get
            {
                return _parentHotelId;
            }
            set
            {
                _parentHotelId = value;
                LoadHotel(value);
            }
        }
        public string RoomId
        {
            get
            {
                return _roomId;
            }
            set
            {
                _roomId = value;
                LoadRoom(value);
            }
        }
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public string Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }
        public string City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }
        public string State
        {
            get => _state;
            set => SetProperty(ref _state, value);
        }
        public string Zipcode
        {
            get => _zipcode;
            set => SetProperty(ref _zipcode, value);
        }
        public string Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }
        public string SqFeet
        {
            get => _sqFeet;
            set => SetProperty(ref _sqFeet, value);
        }
        public string UserFirstName
        {
            get => _userFirstName;
            set => SetProperty(ref _userFirstName, value);
        }
        public string UserLastName
        {
            get => _userLastName;
            set => SetProperty(ref _userLastName, value);
        }
        public string UserEmail
        {
            get => _userEmail;
            set => SetProperty(ref _userEmail, value);
        }
        public string UserPhoneNumber
        {
            get => _userPhoneNumber;
            set => SetProperty(ref _userPhoneNumber, value);
        }
        public DateTime TourDate
        {
            get => _tourDate;
            set => SetProperty(ref _tourDate, value);
        }
        public TimeSpan TourTime
        {
            get => _tourTime;
            set => SetProperty(ref _tourTime, value);
        }
        public string Comments
        {
            get => _comments;
            set => SetProperty(ref _comments, value);
        }
        public string ReservationName { get; set; }

        public RequestTourViewModel()
        {
            Title = "Request A Tour";
            ReservationName = "Tour Reservation";
            TourDate = DateTime.Now;
            TourTime = new DateTime(TourDate.Year, TourDate.Month, TourDate.Day, 8, 0, 0).TimeOfDay;
            Title = "Ask A Question";
            UserFirstName = "John";
            UserLastName = "Smith";
            UserEmail = "Johnsmith@gmail.com";
            UserPhoneNumber = "(949) 705-7313";
            Comments = "";
        }
        private void LoadRoom(string roomId)
        {
            int x = Int32.Parse(roomId);
            if (Hotel != null)
            {
                Room = Hotel.AvailableRooms[x];
                Name = Room.FloorPlan;
                SqFeet = Room.SqFeet;
            }
        }
        private async void LoadHotel(string hotelId)
        {
            var hotel = await HotelStore.GetHotelAsync(hotelId);
            Hotel = hotel;
            Name = hotel.Name;
            Address = hotel.Address;
            City = hotel.City;
            State = hotel.State;
            Zipcode = hotel.ZipCode;
            Country = hotel.Country;
        }
        public void SetTourReservation()
        {
            Reservation res = new Reservation { ReservationId = Guid.NewGuid().ToString(), Name = ReservationName,
                Address = Address + ", " + City + ", " + State + " " + Zipcode,
                RoomType = Room.FloorPlan + " - " + Room.SqFeet + " sqFt", 
                StartDate = "Tour Date: " + TourDate.ToString("ddd, MM/dd/yyyy") + " ", 
                EndDate = new DateTime().Add(TourTime).ToString("hh:mm tt"), ReservationType= "Tour", ReservationTypeIcon="tour.png"};
            ReservationService.AddItemAsync(res);
        }
        

    }
}
