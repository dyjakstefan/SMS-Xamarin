using SMS.Models;
using SMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SMS.Views
{
    /// <summary>
    /// Class for page that shows sms list.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SMSPage : ContentPage
    {
        /// <summary>
        /// SMS view model
        /// </summary>
        SMSViewModel viewModel;

        /// <summary>
        /// Constructor.
        /// </summary>
        public SMSPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new SMSViewModel();
        }

        /// <summary>
        /// This method is called when item is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var sms = args.SelectedItem as SMSModel;
            if (sms == null)
                return;

            await Navigation.PushAsync(new SMSDetailPage(new SMSDetailViewModel(sms)));


            SMSListView.SelectedItem = null;
        }

        /// <summary>
        /// This method is called when "add sms" button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void AddSMS_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewSMSPage()));
        }

        /// <summary>
        /// This method is called when page is appearing.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.SMSCollection.Count == 0)
                viewModel.LoadSMSCommand.Execute(null);
        }
    }
}