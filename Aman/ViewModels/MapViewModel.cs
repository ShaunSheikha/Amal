using Aman.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace Aman.ViewModels
{
    class MapViewModel: BaseViewModel
    {
        private string _zipcode;
        private int _lowerPriceValue;
        private int _upperPriceValue;
        private string _roomType;
        private bool _filtersVisible;

        public string Zipcode
        {
            get => _zipcode;
            set => SetProperty(ref _zipcode, value);
        }
        public int LowerPriceValue 
        { 
            get => _lowerPriceValue;
            set => SetProperty(ref _lowerPriceValue, value); 
        }
        public int UpperPriceValue 
        { 
            get => _upperPriceValue; 
            set => SetProperty(ref _upperPriceValue, value); 
        }
        public string RoomType
        {
            get => _roomType;
            set => SetProperty(ref _roomType, value);
        }
        public bool FiltersVisible
        {
            get => _filtersVisible;
            set => SetProperty(ref _filtersVisible, value);
        }
        public List<Hotel> Hotels;
        public Command ToggleFiltersCommand { get; }
        public MapViewModel()
        {
            Title = "Map";
            Hotels = (List<Hotel>)HotelStore.GetHotelsAsync().Result;
            FiltersVisible = true;
            ToggleFiltersCommand = new Command(() => { FiltersVisible = !FiltersVisible; });
            UpperPriceValue = 10000;
        }
        
    }
}
