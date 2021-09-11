using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace Sparcpoint.Notification
{
    public sealed class EmailSmsNotification : ISmsNotification
    {
        private readonly SmtpEmailOptions _Options;
        public EmailSmsNotification(SmtpEmailOptions options)
        {
            _Options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public async Task SendAsync(PhoneNumber phone, SmsProvider provider, SmsMessage message)
        {
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_Options.Server, _Options.Port, _Options.UseSsl);
                if (_Options.Credentials != null)
                    await client.AuthenticateAsync(_Options.Credentials.Username, _Options.Credentials.Password);

                string toAddress = ToEmailAddress(phone, provider);

                var emailMessage = new MimeMessage();
                emailMessage.From.Add(MailboxAddress.Parse(_Options.FromAddress));
                emailMessage.To.Add(MailboxAddress.Parse(toAddress));
                emailMessage.Subject = _Options.SubjectLine;
                emailMessage.Body = new TextPart("plain")
                {
                    Text = message
                };

                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }

        private string ToEmailAddress(PhoneNumber phone, SmsProvider provider)
        {
            if (!SmsProviders.EmailHosts.TryGetValue(provider, out string emailHost))
                throw new InvalidOperationException("Provider not supported.");

            return $"{phone}@{emailHost}";
        }
    }
}
