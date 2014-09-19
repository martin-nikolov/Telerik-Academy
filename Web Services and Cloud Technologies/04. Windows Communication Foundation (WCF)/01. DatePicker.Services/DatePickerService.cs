namespace DatePicker.Services
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    public class DatePickerService : IServiceDatePicker
    {
        private const string DateTimeFormat = "dddd";

        public string GetDayOfWeek(DateTime date)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("bg-BG");
            return date.ToString(DateTime.Now.ToString(DateTimeFormat));
        }
    }
}