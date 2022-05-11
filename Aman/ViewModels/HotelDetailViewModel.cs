using Aman.Models;
using Aman.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Aman.ViewModels
{
    [QueryProperty(nameof(HotelId), nameof(HotelId))]
    class HotelDetailViewModel : BaseViewModel
    {
        private string _title;
        private string _hotelId;
        private string _name;
        private string _address;
        private string _city;
        private string _state;
        private string _zipcode;
        private string _country;
        private List<Amenity> _amenities;
        private List<Room> _availableRooms;
        private Position _hotelPosition;
        private List<string> _imageNames;
        private string _initialImage;

        public string TitleCaption
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }
        public string HotelId {
            get
            {
                return _hotelId;
            }
            set
            {
                _hotelId = value;
                LoadHotel(value);
            }
        }
        public string Name {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public string Address {
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
        public List<Amenity> Amenities { 
            get => _amenities; 
            set => SetProperty(ref _amenities, value); 
        }
        public List<Room> AvailableRooms
        {
            get => _availableRooms;
            set => SetProperty(ref _availableRooms, value);
        }
        public Position HotelPosition
        {
            get => _hotelPosition;
            set => SetProperty(ref _hotelPosition, value);
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
        public Command ViewSelectedRoomDetails { get; }


        public HotelDetailViewModel()
        {
            RightArrowClickedCommand = new Command((param) => RightArrowClicked(param));
            LeftArrowClickedCommand = new Command((param) => LeftArrowClicked(param));
            ViewSelectedRoomDetails = new Command((param) => ViewSelectedRoomDetailsAsync(param));
        }
        public async void LoadHotel(string hotelId)
        {
            try
            {
                var hotel = await HotelStore.GetHotelAsync(hotelId);
                TitleCaption = hotel.City;
                Name = hotel.Name;
                Address = hotel.Address;
                City = hotel.City;
                State = hotel.State;
                Zipcode = hotel.ZipCode;
                Country = hotel.Country;
                Amenities = hotel.Amentities;
                AvailableRooms = hotel.AvailableRooms;
                ImageNames = hotel.ImageNames;
                InitialImage = ImageNames[0];
                HotelPosition = hotel.HotelPosition;
                
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Hotel");
            }
        }
        public void RightArrowClicked(object sender)
        {
            var currentHotelImage = sender as Image;
            FileImageSource fileImageSource = currentHotelImage.Source as FileImageSource;

            //Change picture by index
            int x = ImageNames.FindIndex((s)=>s == fileImageSource.File);
            if (x==-1)
            {
                return;
            }
            else if(x != ImageNames.Count - 1)
            {
                x++;
                currentHotelImage.Source = ImageNames[x];
            }
            else
            {
                currentHotelImage.Source = ImageNames[ImageNames.Count-1];

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
        public async void ViewSelectedRoomDetailsAsync(object sender)
        {
            //var x = sender as CollectionView;
            //var selectedItem = x.SelectedItem as Room;
            int x = int.Parse(sender.ToString());
            Room selectedItem = AvailableRooms[x];
            if (selectedItem != null)
            {
                await Shell.Current.GoToAsync($"{nameof(RoomDetailPage)}?{nameof(RoomDetailViewModel.RoomId)}={selectedItem.RoomID}&{nameof(RoomDetailViewModel.ParentHotelId)}={selectedItem.ParentHotelID}");
            }
        }


    }
}
