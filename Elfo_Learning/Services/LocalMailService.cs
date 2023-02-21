using System.Diagnostics;

namespace Elfo_Learning.Services
{
    public class LocalMailService : IMailService
    {
        private string _mailto;
        private string _mailfrom;
        public LocalMailService(IConfiguration configuration)
        {
            _mailto = configuration.GetSection("MySettings:To").Value;
            _mailfrom = configuration.GetSection("MySettings:From").Value;
        }
        public void Send(string subject, string message)
        {
            Debug.WriteLine($"Mail send from {_mailfrom} to {_mailto}");
            Debug.WriteLine($"The message is {message}");
            Debug.WriteLine($"The subject is {subject}");
        }
    }
}
