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
    public partial class HotelsPage : ContentPage
    {
        readonly HotelsViewModel _viewModel;
        public HotelsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new HotelsViewModel();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}