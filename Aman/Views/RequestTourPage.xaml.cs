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
    public partial class RequestTourPage : ContentPage
    {
        RequestTourViewModel requestTourViewModel;
        public RequestTourPage()
        {
            InitializeComponent();
            requestTourViewModel = BindingContext as RequestTourViewModel;

        }

        private async void SubmitTourRequestClicked(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(requestTourViewModel.ReservationName))
            {
                requestTourViewModel.ReservationName = "Tour Reservation";
            }
            string confirmationString = $"Your Tour Request Has Been Submitted!\n\n" +
                $"Reservation Name: {requestTourViewModel.ReservationName}\n" +
                $"Date: {requestTourViewModel.TourDate.ToShortDateString()}\n" +
                $"Time: {new DateTime().Add(requestTourViewModel.TourTime).ToString("hh:mm tt")}";

            

            requestTourViewModel.SetTourReservation();

            //Send Email
            SendEmail mail = new SendEmail();
            mail.EmailPriority = SendEmail.MailPriority.HightPriority;
            mail.IsBodyHTML = true;
            mail.EmailBCC = SendEmail.BCC_EMAILS;

            //Send an email with the results
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(RequestTourPage)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("Aman.Resources.Fonts.EmptyTemplate.html");
            string body = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("[FirstName]", "John");
            string Message = "";
            Message = string.Concat(Message, "A customer has a requested a tour:");
            Message = string.Concat(Message, "<br><br>Customer Name: ", userFirstName.Text, " ", userLastName.Text);
            Message = string.Concat(Message, "<br>Customer Phone: ", userPhoneNumber.Text);
            Message = string.Concat(Message, "<br>Customer Email: ", userEmail.Text);
            Message = string.Concat(Message, "<br><u>Comments:</u>");
            Message = string.Concat(Message, "<br>", userComments.Text);
            Message = string.Concat(Message, "<br><u>Tour Info:</u>");
            Message = string.Concat(Message, "<br>", $"Date/Time: {requestTourViewModel.TourDate.ToShortDateString()} {new DateTime().Add(requestTourViewModel.TourTime).ToString("hh:mm tt")}");

            body = body.Replace("[Message]", Message);

            string EmailSent = mail.SendEmailNow("Customer Request Tour - " + userFirstName.Text + " " + userLastName.Text, body,
                new System.Net.Mail.MailAddress(SendEmail.FROM_EMAILS, "AMAL Properties"), SendEmail.TO_EMAILS);

            await DisplayAlert("Thank You!", confirmationString, "OK");
            await Navigation.PopAsync();
            //await Shell.Current.GoToAsync($"{nameof(GenericConfirmationPage)}?{nameof(GenericConfirmationViewModel.ConfirmationString)}={confirmationString}");
        }

    }
}