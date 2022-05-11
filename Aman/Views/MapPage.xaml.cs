using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using System.Diagnostics;
using Aman.ViewModels;
using Aman.Models;

namespace Aman.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage 
    {
        public Location userLocation;
        public Position userPosition;
        readonly MapViewModel mapViewModel;
        public MapPage()
        {
            InitializeComponent();
            mapViewModel = this.BindingContext as MapViewModel;


            MoveToUserLocation();
            AddPins();
        }


        private async void MoveToUserLocation()
        {
            try
            {
                userLocation = await Geolocation.GetLocationAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }

            if (userLocation != null)
            {
                //user position
                userPosition = new Position(userLocation.Latitude, userLocation.Longitude);
            }
            else
            {
                //default position - 36.9628066, -122.0194722 is Santa Cruz
                userPosition = new Position(36.9628066, -122.0194722);
            }

            MapSpan mapSpan = new MapSpan(userPosition, 1, 1);
            map.MoveToRegion(mapSpan);

        }
        private void AddPins()
        {
            map.CustomPins = new List<CustomPin>();
            foreach (Hotel hotel in mapViewModel.Hotels)
            {
                //TODO Apply Filters
                /*if (FilterHotel(hotel))
                {
                    //if hotel passes filter check, add it
                }*/
                string subtitle = $"{hotel.City}, {hotel.State}, {hotel.ZipCode}";
                CustomPin pin = new CustomPin { Label = hotel.Address, Address = subtitle, Type = PinType.Place, Position = hotel.HotelPosition, PinId = hotel.HotelID, AvailableRooms = hotel.AvailableRooms };
                pin.InfoWindowClicked += LocationPinClicked;
                map.Pins.Add(pin);
                map.CustomPins.Add(pin);

            }
        }
        private async void ZipcodeEntered(object sender, EventArgs e)
        {
            var zipEntry = sender as Entry;
            var zipEntered = zipEntry.Text;
            try
            {
                //turn zip into coordinates
                Geocoder geoCoder = new Geocoder();
                IEnumerable<Position> approximateLocations = await geoCoder.GetPositionsForAddressAsync(zipEntered);
                Position position = approximateLocations.FirstOrDefault();

                userPosition = new Position(position.Latitude, position.Longitude);
                MapSpan mapSpan = new MapSpan(userPosition, 1, 1);
                map.MoveToRegion(mapSpan);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        private async void ViewHotelList(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(HotelsPage)}");
        }
        private async void LocationPinClicked(object sender, PinClickedEventArgs e)
        {
            var selectedPinObject = sender as CustomPin;
            var selectedPin = selectedPinObject.PinId;
            await Shell.Current.GoToAsync($"{nameof(HotelDetailPage)}?{nameof(HotelDetailViewModel.HotelId)}={selectedPin}");
        }
        /*private bool FilterHotel(Hotel hotel)
        {
            bool hotelPass = false;
            foreach(Room room in hotel.AvailableRooms)
            {
                if (room.FloorPlan.Equals(mapViewModel.RoomType))
                {
                    hotelPass = true;
                }
            }
            return hotelPass;
        }*/
        private void ApplyButtonClicked(object sender, EventArgs e)
        {
            mapViewModel.FiltersVisible = false;

            MoveToUserLocation();
            AddPins();
        }
    }
}