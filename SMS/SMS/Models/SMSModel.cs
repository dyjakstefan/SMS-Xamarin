using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Models
{
    /// <summary>
    /// SMS Model.
    /// </summary>
    public class SMSModel
    {
        /// <summary>
        /// Id of sms.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Text message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Recipient's phone number.
        /// </summary>
        public string PhoneNumber { get; set; }
    }

    
}
