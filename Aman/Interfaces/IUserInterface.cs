using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aman.Interfaces
{
    public interface IUserInterface<T>
    {
        Task<T> GetUserAsync(string id);
        Task<T> SetUserAsync(T user);
    }
}
