namespace Sparcpoint.Notification
{
    public class SmtpEmailOptions
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public bool UseSsl { get; set; }

        public EmailCredentials Credentials { get; set; }
        public string FromAddress { get; set; }
        public string SubjectLine { get; set; } = "Notification";

        public static SmtpEmailOptions Google(string username, string password, string subjectLine = "Notification")
            => new SmtpEmailOptions
            {
                FromAddress = username,
                SubjectLine = subjectLine,
                UseSsl = true,
                Server = "smtp.gmail.com",
                Port = 465,
                Credentials = new EmailCredentials
                {
                    Username = username,
                    Password = password
                }
            };
    }
}
