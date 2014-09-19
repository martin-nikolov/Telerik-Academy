namespace SubstringModule.Web
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using System.Web.UI;
    using SubstringModule.Services;
    using SubstringModule.Web.ServiceSubstringModule;

    public partial class Default : Page
    {
        private const string HostUrl = "http://localhost:8733/Design_Time_Addresses/SubstringModule.Services/";

        protected void OnGetNumberOfSubstringButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Try to open host -> if host is already open it's throws an exception
                using (var selfHost = HostSubstringModuleService())
                {
                    selfHost.Open();
                    this.GetNumberOfSubstrings();
                }
            }
            catch (Exception)
            {
                // Use already opened host
                this.GetNumberOfSubstrings();
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

        private void GetNumberOfSubstrings()
        {
            var client = new SubstringServiceClient();

            var text = this.TextBox.Text;
            var substring = this.SubStringTextBox.Text;
            this.ResultLabel.Text = "Number of substrings: " + client.GetNumberOfSubstrings(text, substring);
        }
    }
}