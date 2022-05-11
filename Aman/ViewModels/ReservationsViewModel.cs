using Aman.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Aman.ViewModels
{
    public class ReservationsViewModel: BaseViewModel
    {
        private ObservableCollection<Reservation> _myReservations;
        
        public ObservableCollection<Reservation> MyReservations
        {
            get => _myReservations;
            set => SetProperty(ref _myReservations, value);
        }
        public string CancellationReason { get; set; }
        public Command RemoveSelectedReservationCommand { get; }
        public Command LoadReservationsCommand { get; }


        public ReservationsViewModel()
        {
            
            Title = "My Activity";
            MyReservations = new ObservableCollection<Reservation>();
            RemoveSelectedReservationCommand = new Command((param) => RemoveSelectedReservationAsync(param));
            LoadReservationsCommand = new Command(async()=>await LoadReservations());
            
        }

        async Task LoadReservations()
        {
            IsBusy = true;

            try
            {
                MyReservations.Clear();
                var reservations = await ReservationService.GetItemsAsync();
                foreach (var res in reservations)
                {
                    MyReservations.Add(res);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public void OnAppearing()
        {
            //Refreshes the reservation list on page load
            IsBusy = true;
        }
        public async void RemoveSelectedReservationAsync(object sender)
        {
            string result = await Application.Current.MainPage.DisplayPromptAsync("Cancellation Reason", "");
            if (result == null)
            {
                return;
            }
            else
            {
                CancellationReason = result;
                var resId = sender.ToString();
                var selectedRoom = MyReservations.Where(x => x.ReservationId == resId).FirstOrDefault();
                MyReservations.Remove(selectedRoom);
                await ReservationService.DeleteItemAsync(resId.ToString());
            }
        }
    }
}
