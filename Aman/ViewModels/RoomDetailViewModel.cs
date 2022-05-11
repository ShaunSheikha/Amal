using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Aman.Models;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using Aman.Views;

namespace Aman.ViewModels
{
    [QueryProperty(nameof(ParentHotelId), nameof(ParentHotelId))]
    [QueryProperty(nameof(RoomId), nameof(RoomId))]

    class RoomDetailViewModel : BaseViewModel
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
        private List<Amenity> _amenities;
        private Position _unitPosition;
        private List<string> _imageNames;
        private string _initialImage;

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
        public Hotel Hotel { get; set; }
        public string RoomId
        {
            get
            {
                return _roomId;
            }
            set
            {
                _roomId = value;
                LoadRoomId(value);
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
        public List<Amenity> Amenities
        {
            get => _amenities;
            set => SetProperty(ref _amenities, value);
        }
        public Position UnitPosition
        {
            get => _unitPosition;
            set => SetProperty(ref _unitPosition, value);
        }
        public List<string> ImageNames
        {
            get => _imageNames;
            set => SetProperty(ref _imageNames, value);
        }
        public string InitialImage
        {
            get => _initialImage;
            set => SetProperty(ref _initialImage, value);
        }
        public Command RightArrowClickedCommand { get; }
        public Command LeftArrowClickedCommand { get; }
        public Command AskAQuestionClickedCommand { get; }
        public Command RequestTourClickedCommand { get; }
        public Command HoldRoomClickedCommand { get; }

        public RoomDetailViewModel()
        {
            RightArrowClickedCommand = new Command((param) => RightArrowClicked(param));
            LeftArrowClickedCommand = new Command((param) => LeftArrowClicked(param));
            AskAQuestionClickedCommand = new Command((param) => AskAQuestionClickedAsync());
            RequestTourClickedCommand = new Command((param) => RequestTourClickedAsync());
            HoldRoomClickedCommand = new Command(HoldRoomClickedAsync);
        }
        public void LoadRoomId(string roomId)
        {
            int x = Int32.Parse(roomId);
            if(Hotel != null)
            {
                Room room = Hotel.AvailableRooms[x];
                Name = room.FloorPlan + " - " + room.SqFeet + " sqFt";
                SqFeet = room.SqFeet;
                ImageNames = room.ImageNames;
                InitialImage = ImageNames[0];
                Amenities = room.Amenities;
                
            }
            
        }
        public async void LoadHotel(object hotelId)
        {
            var hotel = await HotelStore.GetHotelAsync(hotelId.ToString());
            Hotel = hotel;
            UnitPosition = hotel.HotelPosition;
            Address = hotel.Address;
            City = hotel.City;
            State = hotel.State;
            Zipcode = hotel.ZipCode;
            Country = hotel.Country;

        }
        public void RightArrowClicked(object sender)
        {
            var currentHotelImage = sender as Image;
            FileImageSource fileImageSource = currentHotelImage.Source as FileImageSource;

            //Change picture by index
            int x = ImageNames.FindIndex((s) => s == fileImageSource.File);
            if (x == -1)
            {
                return;
            }
            else if (x != ImageNames.Count - 1)
            {
                x++;
                currentHotelImage.Source = ImageNames[x];
            }
            else
            {
                currentHotelImage.Source = ImageNames[ImageNames.Count - 1];

            }

        }
        public void LeftArrowClicked(object sender)
        {
            var currentHotelImage = sender as Image;
            FileImageSource fileImageSource = currentHotelImage.Source as FileImageSource;

            //Change picture by index
            int x = ImageNames.FindIndex((s) => s == fileImageSource.File);
            if (x == -1)
            {
                return;
            }
            else if (x != 0)
            {
                x--;
                currentHotelImage.Source = ImageNames[x];
            }
            else
            {
                currentHotelImage.Source = ImageNames[0];

            }
        }
        public async void AskAQuestionClickedAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(AskAQuestionPage)}?{nameof(AskAQuestionViewModel.ParentHotelId)}={ParentHotelId}&{nameof(AskAQuestionViewModel.RoomId)}={RoomId}");
        }
        public async void RequestTourClickedAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(RequestTourPage)}?{nameof(RequestTourViewModel.ParentHotelId)}={ParentHotelId}&{nameof(RequestTourViewModel.RoomId)}={RoomId}");
        }
        public async void HoldRoomClickedAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(HoldRequestPage)}?{nameof(HoldRequestViewModel.ParentHotelId)}={ParentHotelId}&{nameof(HoldRequestViewModel.RoomId)}={RoomId}");
        }

    }
}
