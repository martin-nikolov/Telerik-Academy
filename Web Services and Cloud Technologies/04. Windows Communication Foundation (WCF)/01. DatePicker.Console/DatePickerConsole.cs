namespace DatePicker.Console
{
    using System;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using DatePicker.Console.ServiceDatePicker;
    using DatePicker.Services;

    public class DatePickerConsole
    {
        private const string HostUrl = "http://localhost:8733/Design_Time_Addresses/DatePicker/Services";

        internal static void Main()
        {
            try
            {
                // Try to open host -> if host is already opened it's throws an exception
                using (var selfHost = HostSubstringModuleService())
                {
                    selfHost.Open();
                    ShowDayOfWeek();
                }
            }
            catch (Exception)
            {
                // Use already opened host
                ShowDayOfWeek();
            }
        }

        private static ServiceHost HostSubstringModuleService()
        {
            var serviceAddress = new Uri(HostUrl);
            var smb = new ServiceMetadataBehavior()
            {
                HttpGetEnabled = true
            };

            var selfHost = new ServiceHost(typeof(DatePickerService), serviceAddress);
            selfHost.Description.Behaviors.Add(smb);
            return selfHost;
        }

        private static void ShowDayOfWeek()
        {
            var client = new ServiceDatePickerClient();
            var date = DateTime.Now;
            Console.WriteLine("{0:d} -> {1}", date, client.GetDayOfWeek(date));
        }
    }
}