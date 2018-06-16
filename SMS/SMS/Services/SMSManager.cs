using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SMS.Models;

namespace SMS.Services
{
    /// <summary>
    /// Class for managing data flow with web API.
    /// </summary>
    public class SMSManager : IManager
    {
        /// <summary>
        /// Method for getting Http Client.
        /// </summary>
        /// <returns>Http Client.</returns>
        private async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", "No Auth");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.BaseAddress = new Uri("http://192.168.0.102:45455/api/");
            return client;
        }

        /// <summary>
        /// Add new sms to web API. Using POST request.
        /// </summary>
        /// <param name="message">Sms message.</param>
        /// <param name="phoneNumber">Recipient's phone number.</param>
        /// <returns>New sms.</returns>
        public async Task<SMSModel> Add(string message, string phoneNumber)
        {
            HttpClient client = await GetClient();

            SMSModel sms = new SMSModel()
            {
                Message = message,
                PhoneNumber = phoneNumber
            };
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "sms");
                request.Content = new StringContent(JsonConvert.SerializeObject(sms), Encoding.UTF8, "application/json");
                var response = await client.SendAsync(request);
                Debug.WriteLine("Response: {0}", response.StatusCode);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
            }

            return new SMSModel() { Id = Guid.NewGuid(), Message = "asds", PhoneNumber = "34" };
        }

        /// <summary>
        /// Delete specific sms from web API.
        /// </summary>
        /// <param name="Id">Id of sms.</param>
        /// <returns></returns>
        public async Task Delete(Guid Id)
        {
            HttpClient client = await GetClient();
            await client.DeleteAsync("sms/" + Id.ToString());
        }

        /// <summary>
        /// Get all sms from web API.
        /// </summary>
        /// <returns>Collection of sms's</returns>
        public async Task<IEnumerable<SMSModel>> GetAll()
        {
            HttpClient client = await GetClient();

            string result = await client.GetStringAsync("sms");
            return JsonConvert.DeserializeObject<IEnumerable<SMSModel>>(result);
        }
    }

}
