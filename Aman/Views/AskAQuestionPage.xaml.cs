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
    public partial class AskAQuestionPage : ContentPage
    {
        public AskAQuestionPage()
        {
            InitializeComponent();
        }

        private async void SubmitQuestionClicked(object sender, EventArgs e)
        {
            //Send Email
            SendEmail mail = new SendEmail();
            mail.EmailPriority = SendEmail.MailPriority.HightPriority;
            mail.IsBodyHTML = true;
            mail.EmailBCC = SendEmail.BCC_EMAILS;

            //Send an email with the results
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(AskAQuestionPage)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("Aman.Resources.Fonts.EmptyTemplate.html");
            string body = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("[FirstName]", "John");
            string Message = "";
            Message = string.Concat(Message, "A customer has a question:");
            Message = string.Concat(Message, "<br><br>Customer Name: ", userFirstName.Text, " ", userLastName.Text);
            Message = string.Concat(Message, "<br>Customer Phone: ", userPhoneNumber.Text);
            Message = string.Concat(Message, "<br>Customer Email: ", userEmail.Text);
            Message = string.Concat(Message, "<br><u>Question:</u>");
            Message = string.Concat(Message, "<br>", userComments.Text);

            body = body.Replace("[Message]", Message);

            string EmailSent = mail.SendEmailNow("Customer Question - " + userFirstName.Text + " " + userLastName.Text, body,
                new System.Net.Mail.MailAddress(SendEmail.FROM_EMAILS, "AMAL Properties"), SendEmail.TO_EMAILS);

            await DisplayAlert("Thank You!", "The Hotel team will contact you shortly for further assistance.", "OK");
            await Navigation.PopAsync();
            //await Shell.Current.GoToAsync($"{nameof(GenericConfirmationPage)}?{nameof(GenericConfirmationViewModel.ConfirmationString)}={"Your Question Has Been Submitted!"}");
        }
    }
}