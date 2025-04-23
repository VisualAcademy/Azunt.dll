using System.Threading.Tasks;

namespace Azunt.Services
{
    public interface ITwilioSender
    {
        Task SendSmsAsync(string phoneNumber, string message);
    }
}
