using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Sparcpoint.Notification
{
    public sealed class SafeSmsNotification : ISmsNotification
    {
        private readonly ILogger<SafeSmsNotification> _Logger;
        private readonly ISmsNotification _InnerService;

        public SafeSmsNotification(ILogger<SafeSmsNotification> logger, ISmsNotification innerService)
        {
            _Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _InnerService = innerService ?? throw new ArgumentNullException(nameof(innerService));
        }

        public async Task SendAsync(PhoneNumber phone, SmsProvider provider, SmsMessage message)
        {
            try
            {
                await _InnerService.SendAsync(phone, provider, message);
            } catch (Exception ex)
            {
                _Logger.LogError(ex, "Error Occurred sending message: {Message}", ex.Message);
            }
        }
    }
}
