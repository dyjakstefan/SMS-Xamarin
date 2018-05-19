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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SMSPage : ContentPage
    {
        SMSViewModel viewModel;

        public SMSPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new SMSViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var sms = args.SelectedItem as SMSModel;
            if (sms == null)
                return;

            await Navigation.PushAsync(new SMSDetailPage(new SMSDetailViewModel(sms)));


            SMSListView.SelectedItem = null;
        }

        async void AddSMS_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewSMSPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.SMSCollection.Count == 0)
                viewModel.LoadSMSCommand.Execute(null);
        }
    }
}