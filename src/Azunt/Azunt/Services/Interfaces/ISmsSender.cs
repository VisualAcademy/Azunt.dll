using System.Threading.Tasks;

namespace Azunt.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
