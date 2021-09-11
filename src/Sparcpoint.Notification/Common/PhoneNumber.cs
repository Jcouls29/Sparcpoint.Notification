using System;
using System.Text.RegularExpressions;

namespace Sparcpoint.Notification
{
    public struct PhoneNumber
    {
        private PhoneNumber(int areaCode, int officeCode, int lineNumber, int countryCode = 1)
        {
            AreaCode = areaCode;
            OfficeCode = officeCode;
            LineNumber = lineNumber;
            CountryCode = countryCode;
        }

        public int CountryCode { get; }
        public int AreaCode { get; }
        public int OfficeCode { get; }
        public int LineNumber { get; }

        public override string ToString()
            => $"{CountryCode}{AreaCode.ToString("000")}{OfficeCode.ToString("000")}{LineNumber.ToString("0000")}";

        public static implicit operator string(PhoneNumber number)
            => number.ToString();

        public static implicit operator PhoneNumber(string number)
            => Parse(number);

        private static Regex REPLACE_PATTERN = new Regex(@"\D+");
        public static bool TryParse(string text, out PhoneNumber value)
        {
            value = default;
            string cleaned = REPLACE_PATTERN.Replace(text, "");

            if (cleaned.Length < 10)
                return false;

            int countryCode = 1;
            if (cleaned.Length > 10)
            {
                var ccText = cleaned.Substring(0, cleaned.Length - 10);
                countryCode = int.Parse(ccText);
            }

            string primary = cleaned.Substring(cleaned.Length - 10);
            int areaCode = int.Parse(primary.Substring(0, 3));
            int officeCode = int.Parse(primary.Substring(3, 3));
            int lineNumber = int.Parse(primary.Substring(6));

            value = new PhoneNumber(areaCode, officeCode, lineNumber, countryCode);
            return true;
        }

        public static PhoneNumber Parse(string text)
        {
            if (!TryParse(text, out PhoneNumber value))
                throw new ArgumentException("Invalid phone number format.");
            return value;
        }
    }
}
