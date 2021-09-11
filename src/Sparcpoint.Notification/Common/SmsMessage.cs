using System;

namespace Sparcpoint.Notification
{
    public class SmsMessage
    {
        private SmsMessage(string message)
        {
            Message = message;
        }

        public string Message { get; }

        public static implicit operator string(SmsMessage message)
            => message.Message;

        public static implicit operator SmsMessage(string message)
            => Create(message);

        public static SmsMessage Create(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Cannot create an empty message.");

            var cleaned = message.Trim();
            if (cleaned.Length > 160)
                throw new ArgumentException("Message is too long. Maximum length of 160 characters.");

            return new SmsMessage(cleaned);
        }
    }
}
