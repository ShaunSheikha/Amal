using Aman.ViewModels;
using Aman.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Aman
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AskAQuestionPage), typeof(AskAQuestionPage));
            Routing.RegisterRoute(nameof(GenericConfirmationPage), typeof(GenericConfirmationPage));
            Routing.RegisterRoute(nameof(HoldRequestPage), typeof(HoldRequestPage));
            Routing.RegisterRoute(nameof(HotelDetailPage), typeof(HotelDetailPage));
            Routing.RegisterRoute(nameof(HotelsPage), typeof(HotelsPage));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(MapPage), typeof(MapPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(RoomDetailPage), typeof(RoomDetailPage));
            Routing.RegisterRoute(nameof(RequestTourPage), typeof(RequestTourPage));
            
        }
        private async void OnMenuLoginClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
        private async void OnMenuLogoutClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
    }
}
