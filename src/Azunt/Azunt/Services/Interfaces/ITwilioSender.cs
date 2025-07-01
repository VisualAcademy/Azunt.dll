using System.Threading.Tasks;

namespace Azunt.Services // All.Services
{
    public interface ITwilioSender
    {
        Task SendSmsAsync(string phoneNumber, string message);
    }
}
