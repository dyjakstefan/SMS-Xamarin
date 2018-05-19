using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using SMS.Models;

namespace SMS.Services
{
    public interface IManager
    {
        Task<IEnumerable<SMSModel>> GetReadyToSend();
        Task<SMSModel> Add(string message, string phoneNumber);
        Task Delete(Guid Id);
    }
}
