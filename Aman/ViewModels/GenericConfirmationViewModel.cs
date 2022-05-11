using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Aman.ViewModels
{
    [QueryProperty(nameof(ConfirmationString), nameof(ConfirmationString))]
    public class GenericConfirmationViewModel: BaseViewModel
    {
        private string _confirmationString;
        public string ConfirmationString { 
            get => _confirmationString;
            set => SetProperty(ref _confirmationString, value); 
        }
        public GenericConfirmationViewModel()
        {
            Title = "Confirmation";
        }
    }
}
