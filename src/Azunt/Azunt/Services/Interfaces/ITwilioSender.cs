using System.Threading.Tasks;

namespace Azunt.Services // All.Services
{
    /// <summary>
    /// ITwilioSender 서비스 인터페이스 추가: https://youtu.be/5MrgBXJ1Va8
    /// ITwilioSender 인터페이스 파일을 Azunt 프로젝트에 추가: https://youtu.be/JiXhL9eXFyM
    /// </summary>
    public interface ITwilioSender
    {
        Task SendSmsAsync(string phoneNumber, string message);
    }
}
