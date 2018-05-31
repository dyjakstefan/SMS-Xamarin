using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Messaging;
using SMS.Services;
using SMS.Views;
using Xamarin.Forms;

namespace SMS
{
    
    public partial class App : Application
	{
        public IManager SMSManager => DependencyService.Get<IManager>() ?? new SMSManager();


        public App ()
		{
			InitializeComponent();

            MainPage = new MainPage();
            
            
        }

		protected override void OnStart ()
		{
            
            Task.Run(async () =>
            {
                
                while (true)
                {
                    await Task.Delay(10000);
                    var smsList = await SMSManager.GetReadyToSend();
                    foreach (var s in smsList)
                    {
                        
                        var smsMessenger = CrossMessaging.Current.SmsMessenger;
                        if (smsMessenger.CanSendSmsInBackground)
                        {
                            try
                            {
                                smsMessenger.SendSmsInBackground(s.PhoneNumber, s.Message);
                            }
                            catch(Exception ex)
                            {
                                Debug.WriteLine(ex.Message);
                            }
                            await SMSManager.Delete(s.Id);
                        }
                        else
                        {
                            Debug.WriteLine("Can't send sms");
                        }

                    }
                }
            });
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
