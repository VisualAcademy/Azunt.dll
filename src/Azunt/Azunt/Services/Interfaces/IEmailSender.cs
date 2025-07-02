using System.Threading.Tasks;

namespace Azunt.Services // All.Services
{
    /// <summary>
    /// Provides functionality for sending emails.
    /// IEmailSender 인터페이스 파일을 Azunt 프로젝트에 추가: https://youtu.be/dryTN9ydj5o
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Sends an email asynchronously.
        /// </summary>
        /// <param name="email">Recipient email address.</param>
        /// <param name="subject">Email subject.</param>
        /// <param name="message">Email body content.</param>
        /// <param name="isBodyHtml">Specifies whether the email body is in HTML format. (Default: true)</param>
        Task SendEmailAsync(string email, string subject, string message, bool isBodyHtml = true);
    }

    /// <summary>
    /// Provides functionality for sending emails using Mailchimp.
    /// </summary>
    public interface IMailchimpEmailSender
    {
        /// <summary>
        /// Sends an email asynchronously using Mailchimp.
        /// </summary>
        /// <param name="email">Recipient email address.</param>
        /// <param name="subject">Email subject.</param>
        /// <param name="message">Email body content.</param>
        /// <param name="isBodyHtml">Specifies whether the email body is in HTML format. (Default: true)</param>
        Task SendEmailAsync(string email, string subject, string message, bool isBodyHtml = true);
    }
}
