using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using SMS.Models;

namespace SMS.Services
{
    /// <summary>
    /// Interface for manager.
    /// </summary>
    public interface IManager
    {
        /// <summary>
        /// Get all sms from web API.
        /// </summary>
        /// <returns>Collection of sms's</returns>
        Task<IEnumerable<SMSModel>> GetAll();

        /// <summary>
        /// Add new sms to web API. Using POST request.
        /// </summary>
        /// <param name="message">Sms message.</param>
        /// <param name="phoneNumber">Recipient's phone number.</param>
        /// <returns>New sms.</returns>
        Task<SMSModel> Add(string message, string phoneNumber);

        /// <summary>
        /// Delete specific sms from web API.
        /// </summary>
        /// <param name="Id">Id of sms.</param>
        /// <returns></returns>
        Task Delete(Guid Id);
    }
}
