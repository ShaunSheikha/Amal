using Aman.Services;
using Aman.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aman.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HoldRequestPage : ContentPage
    {
        readonly HoldRequestViewModel _viewModel;
        public HoldRequestPage()
        {
            InitializeComponent();
            _viewModel = BindingContext as HoldRequestViewModel;
            
        }

        private async void SubmitHoldRequestClicked(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(_viewModel.ReservationName))
            {
                _viewModel.ReservationName = "Hold Reservation";
            }
            else
            {
                _viewModel.ReservationName = "Hold";
                _viewModel.ReservationName = _viewModel.ReservationName + " - " + _viewModel.Address;
                _viewModel.ReservationName = _viewModel.ReservationName + " - " + _viewModel.Name + " " + _viewModel.SqFeet + " sqFt";
            }

            string confirmationString = $"Your Hold Request Has Been Submitted!\n\n" +
                $"Reservation Name: {_viewModel.ReservationName}\n" +
                $"Date: {_viewModel.TourStartDate.ToShortDateString()} - {_viewModel.TourEndDate.ToShortDateString()}\n" +
                $"Payment Type: { _viewModel.PaymentType}";

            

            _viewModel.SetReservation();

            //Send Email
            SendEmail mail = new SendEmail();
            mail.EmailPriority = SendEmail.MailPriority.HightPriority;
            mail.IsBodyHTML = true;
            mail.EmailBCC = SendEmail.BCC_EMAILS;

            //Send an email with the results
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(HoldRequestPage)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("Aman.Resources.Fonts.EmptyTemplate.html");
            string body = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("[FirstName]", "John");
            string Message = "";
            Message = string.Concat(Message, "A customer has a question:");
            Message = string.Concat(Message, "<br><br>Customer Name: John Smith");
            Message = string.Concat(Message, "<br>Customer Phone: ", "858-344-8390");
            Message = string.Concat(Message, "<br>Customer Email: ", "khenawy@gmail.com");
            Message = string.Concat(Message, "<br><u>Unit Held:</u>");
            Message = string.Concat(Message, "<br>", _viewModel.Address);
            Message = string.Concat(Message, "<br>", _viewModel.City + ", " + _viewModel.State + " " + _viewModel.Zipcode);
            Message = string.Concat(Message, "<br>", _viewModel.Name + " - " + _viewModel.SqFeet);
            Message = string.Concat(Message, "<br><br><u>Reservation Hold Date:</u>");
            Message = string.Concat(Message, "<br>", _viewModel.TourStartDate.ToString("MM/dd/yyyy") + " - " + _viewModel.TourEndDate.ToString("MM/dd/yyyy"));
            Message = string.Concat(Message, "<br><br><u>Payment Info:</u>");
            Message = string.Concat(Message, "<br>", _viewModel.PaymentType);

            body = body.Replace("[Message]", Message);

            string EmailSent = mail.SendEmailNow("Customer Reservation Hold", body,
                new System.Net.Mail.MailAddress(SendEmail.FROM_EMAILS, "AMAL Properties"), SendEmail.TO_EMAILS);

            await DisplayAlert("Thank You!", confirmationString.Replace("Reservation Name: ", ""), "OK");
            await Navigation.PopAsync();
            //await Shell.Current.GoToAsync($"{nameof(GenericConfirmationPage)}?{nameof(GenericConfirmationViewModel.ConfirmationString)}={confirmationString}");
        }
    }
}