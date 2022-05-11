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
    public partial class GenericConfirmationPage : ContentPage
    {
        GenericConfirmationViewModel _viewModel;
        public GenericConfirmationPage()
        {
            InitializeComponent();
            _viewModel = BindingContext as GenericConfirmationViewModel;

        }

        private async void ConfirmationButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
            //await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
    }
}