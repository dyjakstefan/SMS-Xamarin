using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SMS.Models;

namespace SMS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewSMSPage : ContentPage
    {
        public SMSModel SMSModel { get; set; }
        public NewSMSPage()
        {
            InitializeComponent();
            SMSModel = new SMSModel
            {
                Message = "",
                PhoneNumber = ""
            };

            BindingContext = SMSModel;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", SMSModel);
            await Navigation.PopModalAsync();
        }
    }
}