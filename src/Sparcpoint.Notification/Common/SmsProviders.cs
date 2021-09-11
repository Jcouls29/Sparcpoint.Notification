using System.Collections.Generic;

namespace Sparcpoint.Notification
{
    public static class SmsProviders
    {
        public static IReadOnlyDictionary<SmsProvider, string> EmailHosts { get; } = new Dictionary<SmsProvider, string>
        {
            { SmsProvider.ATT, "mms.att.net" },
            { SmsProvider.Cricket, "mms.cricketwireless.net" },
            { SmsProvider.GoogleProjectFi, "msg.fi.google.com" },
            { SmsProvider.RepublicWireless, "text.republicwireless.com" },
            { SmsProvider.StraightTalk, "mypixmessages.com" },
            { SmsProvider.BoostMobile, "myboostmobile.com" },
            { SmsProvider.MetroPCS, "mymetropcs.com" },
            { SmsProvider.Sprint, "pm.sprint.com" },
            { SmsProvider.Ting, "message.ting.com" },
            { SmsProvider.TMobile, "tmomail.net" },
            { SmsProvider.Tracfone, "mmst5.tracfone.com" },
            { SmsProvider.USCellular, "mms.uscc.net" },
            { SmsProvider.Verizon, "vzwpix.com" },
            { SmsProvider.VirginMobile, "vmpix.com" },
        };
    }
}
