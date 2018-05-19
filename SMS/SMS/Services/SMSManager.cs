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
    public class SMSManager : IManager
    {
        private async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", "No Auth");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.BaseAddress = new Uri("http://192.168.0.108:5000/api/");
            return client;
        }

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

        public async Task Delete(Guid Id)
        {
            HttpClient client = await GetClient();
        }

        public async Task<IEnumerable<SMSModel>> GetReadyToSend()
        {
            HttpClient client = await GetClient();

            string result = await client.GetStringAsync("sms");
            return JsonConvert.DeserializeObject<IEnumerable<SMSModel>>(result);
        }
    }

}
