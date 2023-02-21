namespace Elfo_Learning.Services
{
    public interface IMailService
    {
        void Send(string subject, string message);
    }
}
