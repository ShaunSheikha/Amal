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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            
        }
        
        private async void SearchStarted(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(MapPage)}");

        }

        
    }
}