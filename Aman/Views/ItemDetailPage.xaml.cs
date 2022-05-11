using Aman.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Aman.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}