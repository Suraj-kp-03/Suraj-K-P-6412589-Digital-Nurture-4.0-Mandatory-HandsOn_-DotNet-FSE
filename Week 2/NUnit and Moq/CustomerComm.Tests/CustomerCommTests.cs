using NUnit.Framework;      
using Moq;                         
using CustomerComm;            

namespace CustomerComm.Tests
{
    [TestFixture]            
    public class CustomerCommTests
    {
        private Mock<IMailSender> _mockMailSender; 
        private CustomerComm _customerComm;

        [OneTimeSetUp]          
        public void Init()
        {
            _mockMailSender = new Mock<IMailSender>(); // Mocking IMailSender for the testing purpose.

            _mockMailSender
                .Setup(m => m.SendMail("cust123@abc.com", "Some Message"))
                .Returns(true);

            _customerComm = new CustomerComm(_mockMailSender.Object); // Inject the mock into the class under test
        }

        [Test]                      
        public void SendMailToCustomer_ReturnsTrue_WhenMockedSendSucceeds()
        {
            
            bool result = _customerComm.SendMailToCustomer();

            Assert.That(result, Is.True); // Expected Assert Method should to return true.

            _mockMailSender.Verify(
                m => m.SendMail("cust123@abc.com", "Some Message"),
                Times.Once); // Expected SendMail to be called exactly once with any two string arguments.
        }
    }
}
