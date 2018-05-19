using SMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.ViewModels
{
    public class SMSDetailViewModel : BaseViewModel
    {
        public SMSModel SMSModel { get; set; }
        public SMSDetailViewModel(SMSModel sms = null)
        {
            SMSModel = sms;
        }
    }
}
