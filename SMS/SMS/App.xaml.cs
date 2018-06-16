using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Messaging;
using SMS.Services;
using SMS.Views;
using Xamarin.Forms;

namespace SMS
{
    /// <summary>
    /// The main class for application.
    /// </summary>
    public partial class App : Application
	{
        /// <summary>
        /// Instance of SMSManager.
        /// </summary>
        public IManager SMSManager => DependencyService.Get<IManager>() ?? new SMSManager();

        /// <summary>
        /// Constructor.
        /// </summary>
        public App ()
		{
			InitializeComponent();

            MainPage = new MainPage();
            
            
        }

        /// <summary>
        /// This method is called when application starts.
        /// </summary>
		protected override void OnStart ()
		{
            
            Task.Run(async () =>
            {
                
                while (true)
                {
                    await Task.Delay(10000);
                    var smsList = await SMSManager.GetAll();
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

        /// <summary>
        /// This method is called when application sleeps.
        /// </summary>
        protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

        /// <summary>
        /// This method is called when application resumes.
        /// </summary>
        protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
