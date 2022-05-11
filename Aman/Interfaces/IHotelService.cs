using Aman.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aman.Interfaces
{
    public interface IHotelService<T>
    {
        Task<T> GetHotelAsync(string id);
        Task<IEnumerable<T>> GetHotelsAsync(bool forceRefresh = false);

    }
}
