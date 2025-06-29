using System.Net;
using System.Net.Mail;

namespace CustomerComm
{

    public interface IMailSender
    {
        bool SendMail(string toAddress, string message);
    }
}