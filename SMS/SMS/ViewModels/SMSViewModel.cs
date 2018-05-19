using SMS.Models;
using SMS.Services;
using SMS.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SMS.ViewModels
{
    public class SMSViewModel : BaseViewModel
    { 
        public ObservableCollection<SMSModel> SMSCollection { get; set; }
        public Command LoadSMSCommand { get; set; }
        

        public SMSViewModel()
        {
            Title = "SMS";
            SMSCollection = new ObservableCollection<SMSModel>();
            LoadSMSCommand = new Command(async () => await ExecuteLoadSMSCommand());

            MessagingCenter.Subscribe<NewSMSPage, SMSModel>(this, "AddItem", async (obj, sms) =>
            {
                var _sms = sms as SMSModel;
                SMSCollection.Add(_sms);

                await SMSManager.Add(_sms.Message, _sms.PhoneNumber);
                await SMSManager.Delete(Guid.NewGuid());
            });
        }

        async Task ExecuteLoadSMSCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                SMSCollection.Clear();
                var smsList = await SMSManager.GetReadyToSend();
                foreach (var s in smsList)
                {
                    SMSCollection.Add(s);
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
    }
}