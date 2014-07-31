namespace Phonebook.Common
{
    using System;
    using System.Linq;
    using System.Text;

    public static class StringExtensions
    {
        private const string DefaultPhonePrefix = "+359";

        public static string ConvertPhoneToCannonicalForm(this string phoneNumber, string phonePrefix = DefaultPhonePrefix)
        {
            var phoneNumberToCannonicalForm = new StringBuilder();
            foreach (char ch in phoneNumber)
            {
                if (char.IsDigit(ch) || (ch == '+'))
                {
                    phoneNumberToCannonicalForm.Append(ch);
                }
            }

            if (phoneNumberToCannonicalForm.Length >= 2 &&
                phoneNumberToCannonicalForm[0] == '0' && phoneNumberToCannonicalForm[1] == '0')
            {
                phoneNumberToCannonicalForm.Remove(0, 1);
                phoneNumberToCannonicalForm[0] = '+';
            }

            while (phoneNumberToCannonicalForm.Length > 0 && phoneNumberToCannonicalForm[0] == '0')
            {
                phoneNumberToCannonicalForm.Remove(0, 1);
            }

            if (phoneNumberToCannonicalForm.Length > 0 && phoneNumberToCannonicalForm[0] != '+')
            {
                phoneNumberToCannonicalForm.Insert(0, phonePrefix);
            }

            return phoneNumberToCannonicalForm.ToString();
        }
    }
}