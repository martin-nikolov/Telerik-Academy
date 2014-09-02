namespace CrowdChat.WPF
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows;
    using CrowdChat.Data;
    using CrowdChat.Models;

    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private const string GitHubUri = "http://www.github.com/flextry";

        public LoginWindow()
        {
            this.InitializeComponent();
            this.usernameTextBox.Focus();
        }

        private void OnSignUpButtonClick(object sender, RoutedEventArgs e)
        {
            var username = this.usernameTextBox.Text;

            if (!CrowdChatValidation.IsValidUsername(username))
            {
                return;
            }

            this.Hide();
            this.ShowCrowdChatWindow(username);
            this.Close();
        }
 
        private void ShowCrowdChatWindow(string username)
        {
            var user = new UserSession(username);
            var mainWindow = new CrowdChatWindow(user);
            mainWindow.Show();
        }

        private void OnGitHubButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(GitHubUri));
            }
            catch (Exception)
            {
            }

            e.Handled = true;
        }
    }
}