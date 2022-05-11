using Aman.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aman.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoomDetailPage : ContentPage
    {
        public RoomDetailPage()
        {
            InitializeComponent();
        }

        private async void HoldButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

    }
}