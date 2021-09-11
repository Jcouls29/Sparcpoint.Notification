# Sparcpoint.Notification
> Version: 1.0.0

A simple library that provides notification messaging utilizing varying networks.

> NOTE: Only supports email-based SMS notifications currently

## Installation

### Package Manager Console

```PowerShell
Install-Package Sparcpoint.Notification
```

### .NET Core CLI

```bash
dotnet add package Sparcpoint.Notification
```

## Usage

### SMS Provider
In order to send via SMS Text Messages is to utilize the `Sparcpoint.Notification.ISmsNotification` interface.

#### Email-based Notification
To utilize an SMTP relay to send text messages, use the `EmailSmsNotification` implementation.

```csharp
ISmsNotification notifier = new EmailSmsNotification(new SmtpEmailOptions 
{
    Server = "smtp.gmail.com",
    Port = 465,
    UseSsl = true,
    Credentials = new EmailCredentials 
    {
        Username = "<Username>",
        Password = "<Password>"
    }
});

// If using google, a shorthand approach is to use the following:
ISmsNotification notifier = new EmailSmsNotification(
    SmtpEmailOptions.Google("<Username>", "<Password>")
);

await notifier.SendAsync(
    PhoneNumber.Parse("555-555-5555"), 
    SmsProvider.Verizon, 
    SmsMessage.Create("Your notification is here.")
);
```

