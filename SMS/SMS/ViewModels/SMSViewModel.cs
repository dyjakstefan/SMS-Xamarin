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
    /// <summary>
    /// View model for page with sms list.
    /// </summary>
    public class SMSViewModel : BaseViewModel
    { 
        /// <summary>
        /// Collection of sms.
        /// </summary>
        public ObservableCollection<SMSModel> SMSCollection { get; set; }
        public Command LoadSMSCommand { get; set; }
        
        /// <summary>
        /// Constructor.
        /// </summary>
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

        /// <summary>
        /// This method execute command that loads sms list.
        /// </summary>
        /// <returns></returns>
        async Task ExecuteLoadSMSCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                SMSCollection.Clear();
                var smsList = await SMSManager.GetAll();
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