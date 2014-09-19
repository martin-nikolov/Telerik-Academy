namespace SubstringModule.Console
{
    using System;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using SubstringModule.Console.ServiceSubstringModule;
    using SubstringModule.Services;

    public class SubstringModuleConsole
    {
        private const string HostUrl = "http://localhost:8733/Design_Time_Addresses/SubstringModule.Services/";

        internal static void Main()
        {
            try
            {
                // Try to open host -> if host is already open it's throws an exception
                using (var selfHost = HostSubstringModuleService())
                {
                    selfHost.Open();
                    GetNumberOfSubstrings();
                }
            }
            catch (Exception)
            {
                // Use already opened host
                GetNumberOfSubstrings();
            }
        }
 
        private static ServiceHost HostSubstringModuleService()
        {
            var serviceAddress = new Uri(HostUrl);
            var smb = new ServiceMetadataBehavior()
            {
                HttpGetEnabled = true
            };

            var selfHost = new ServiceHost(typeof(SubstringService), serviceAddress);
            selfHost.Description.Behaviors.Add(smb);
            return selfHost;
        }

        private static void GetNumberOfSubstrings()
        {
            var client = new SubstringServiceClient();

            string text = "alalal";
            string substring = "al";
            int numberOfSubstrings = client.GetNumberOfSubstrings(text, substring);
            Console.WriteLine("Text: {0} | Substring: {1} -> number of substrings: {2}",
                text, substring, numberOfSubstrings);
        }
    }
}