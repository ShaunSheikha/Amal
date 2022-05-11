using Aman.Interfaces;
using Aman.Models;
using Aman.Services;
using Aman.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Montserrat-Regular.ttf", Alias = "Montserrat")]
[assembly: ExportFont("Assistant-Regular.ttf", Alias = "Assistant")]
[assembly: ExportFont("Assistant-Bold.ttf", Alias = "Bold-Assistant")]
[assembly: ExportFont("Questrial-Regular.ttf", Alias = "Questrial")]


namespace Aman
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<HotelService>();
            DependencyService.Register<UserService>();
            DependencyService.Register<ReservationService>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
