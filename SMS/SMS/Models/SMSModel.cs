using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Models
{
    public class SMSModel
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string PhoneNumber { get; set; }
    }

    
}
