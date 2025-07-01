using System.Threading.Tasks;

namespace Azunt.Services
{
    /// <summary>
    /// ISmsSender 인터페이스 파일 추가: https://youtu.be/nTDjYUqpuhY
    /// </summary>
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
