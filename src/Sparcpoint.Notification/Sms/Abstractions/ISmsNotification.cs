using System.Threading.Tasks;

namespace Sparcpoint.Notification
{
    public interface ISmsNotification
    {
        Task SendAsync(PhoneNumber phone, SmsProvider provider, SmsMessage message);
    }
}
