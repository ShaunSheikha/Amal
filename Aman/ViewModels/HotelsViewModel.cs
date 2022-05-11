using Aman.Models;
using Aman.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Aman.ViewModels
{
    class HotelsViewModel: BaseViewModel
    {
        private Hotel _selectedHotel;
        public Hotel SelectedHotel
        {
            get => _selectedHotel;
            set
            {
                SetProperty(ref _selectedHotel, value);
                OnHotelSelected(value);
            }
        }
        public ObservableCollection<Hotel> Hotels { get; }
        public Command LoadHotelsCommand { get; }
        public Command<Hotel> HotelTapped { get; }
        public HotelsViewModel()
        {
            Title = "Hotels";
            Hotels = new ObservableCollection<Hotel>();
            LoadHotelsCommand = new Command(async () => await ExecuteLoadHotelsCommand());
            HotelTapped = new Command<Hotel>(OnHotelSelected);
        }
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedHotel = null;
        }
        async Task ExecuteLoadHotelsCommand()
        {
            IsBusy = true;

            try
            {
                Hotels.Clear();
                var hotels = await HotelStore.GetHotelsAsync(true);
                foreach(var hotel in hotels)
                {
                    hotel.CityStateZip = hotel.City + ", " + hotel.State + " " + hotel.ZipCode;
                    hotel.AvailableRoomsList = "";
                    foreach (Room room in hotel.AvailableRooms)
                    {
                        hotel.AvailableRoomsList = hotel.AvailableRoomsList + "\r\n" + room.FloorPlan + " - " + room.SqFeet + " sqFt";
                    }
                    Hotels.Add(hotel);
                }
                
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
                IsBusy = false;
            }
        }
        async void OnHotelSelected(Hotel hotel)
        {
            if (hotel == null)
                return;

            // This will push the HotelDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(HotelDetailPage)}?{nameof(HotelDetailViewModel.HotelId)}={hotel.HotelID}");
        }
    }
}
