using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SMS.Models;

namespace SMS.Views
{
    /// <summary>
    /// Class for page that shows the form for new sms.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewSMSPage : ContentPage
    {
        /// <summary>
        /// SMS model.
        /// </summary>
        public SMSModel SMSModel { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
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

        /// <summary>
        /// This method is called when button "Save" is clicked. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", SMSModel);
            await Navigation.PopModalAsync();
        }
    }
}