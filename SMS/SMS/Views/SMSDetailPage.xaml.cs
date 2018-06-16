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
    /// Class for page that shows sms details.
    /// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SMSDetailPage : ContentPage
    {
        SMSDetailViewModel viewModel;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="viewModel"></param>
        public SMSDetailPage(SMSDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public SMSDetailPage()
        {
            InitializeComponent();

            var sms = new SMSModel
            {
                Message = "Message",
                PhoneNumber = "000000000"
            };

            viewModel = new SMSDetailViewModel(sms);
            BindingContext = viewModel;
        }
    }
}