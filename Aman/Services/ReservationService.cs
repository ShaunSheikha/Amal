using Aman.Interfaces;
using Aman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aman.Services
{
    public class ReservationService : IDataStore<Reservation>
    {
        readonly List<Reservation> reservations;
        public ReservationService()
        {
            reservations = new List<Reservation>()
            {
               /* new Reservation { ReservationId = Guid.NewGuid().ToString(), Name = "June Work Trip", Address = "Address", RoomType = "Studio", StartDate = "6/30/22", EndDate = "7/15/22", PaymentType = "Credit Card" },
                new Reservation { ReservationId = Guid.NewGuid().ToString(), Name = "Friend Vacation", Address = "Address", RoomType = "Penthouse", StartDate = "9/30/22", EndDate = "10/15/22", PaymentType = "Debit Card"  },
                new Reservation { ReservationId = Guid.NewGuid().ToString(), Name = "December Conference", Address = "Address", RoomType = "Suite", StartDate = "12/1/22", EndDate = "12/15/22", PaymentType = "Debit Card"  }
*/
            };
        }
        public async Task<bool> AddItemAsync(Reservation res)
        {
            reservations.Add(res);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = reservations.Where((Reservation res) => res.ReservationId == id).FirstOrDefault();
            reservations.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public Task<Reservation> GetItemAsync(string id)
        {
            return Task.FromResult(reservations.Find(s => s.ReservationId == id));
        }

        public async Task<IEnumerable<Reservation>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(reservations);
        }

        public Task<bool> UpdateItemAsync(Reservation item)
        {
            throw new NotImplementedException();
        }
    }
}
