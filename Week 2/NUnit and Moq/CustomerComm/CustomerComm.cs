using CustomerComm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerComm
{
    public class CustomerComm(IMailSender mailSender)
    {
        private readonly IMailSender _mailSender = mailSender;

        public bool SendMailToCustomer()
        {
            bool result = _mailSender.SendMail("cust123@abc.com", "Some Message");
            return result;
        }
    }
}
