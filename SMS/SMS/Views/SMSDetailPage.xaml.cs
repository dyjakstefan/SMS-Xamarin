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
	public partial class SMSDetailPage : ContentPage
    {
        SMSDetailViewModel viewModel;

        public SMSDetailPage(SMSDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

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