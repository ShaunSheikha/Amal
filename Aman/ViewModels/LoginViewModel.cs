using Aman.Models;
using Aman.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Aman.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _userName;
        private string _password;

        public User User { get; set; }
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            User = new User();
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            User.UserName = UserName;
            User.Password = Password;
            await UserService.SetUserAsync(User);
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
    }
}
