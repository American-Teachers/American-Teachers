using System.Threading.Tasks;

namespace AtApi.Framework
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
