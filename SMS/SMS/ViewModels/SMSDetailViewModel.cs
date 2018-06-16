using SMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.ViewModels
{
    /// <summary>
    /// View model for page with sms details.
    /// </summary>
    public class SMSDetailViewModel : BaseViewModel
    {
        /// <summary>
        /// SMS model.
        /// </summary>
        public SMSModel SMSModel { get; set; }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="sms"></param>
        public SMSDetailViewModel(SMSModel sms = null)
        {
            SMSModel = sms;
        }
    }
}
