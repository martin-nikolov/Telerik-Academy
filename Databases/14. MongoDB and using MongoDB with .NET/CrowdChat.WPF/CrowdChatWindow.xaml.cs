namespace CrowdChat.WPF
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows;
    using CrowdChat.Data;
    using CrowdChat.Models;

    /// <summary>
    /// Interaction logic for CrowdChatWindow.xaml
    /// </summary>
    public partial class CrowdChatWindow : Window
    {
        private const string GitHubUri = "http://www.github.com/flextry";

        CrowdChatModule crowdChatModule;

        public CrowdChatWindow(User user)
        {
            this.InitializeComponent();
            this.User = user;
        }

        private User User { get; set; }

        private void OnWindowFormLoaded(object sender, RoutedEventArgs e)
        {
            this.InitializeCrowdChatModule();
            this.ShowAllPosts();
            this.allPostsTextBox.ScrollToEnd();
            this.postContent.Focus();
        }

        private void InitializeCrowdChatModule()
        {
            var mongoDbContext = new MongoDbContext();
            this.crowdChatModule = new CrowdChatModule(mongoDbContext);
        }

        private void ShowAllPosts()
        {
            var postsAsString = this.crowdChatModule.GenerateAllPostsAsString();
            this.allPostsTextBox.Text = postsAsString.ToString();
        }

        private void OnPostButtonClick(object sender, RoutedEventArgs e)
        {
            var postContent = this.postContent.Text;
            if (string.IsNullOrEmpty(postContent))
            {
                return;
            }

            var postModel = new Post()
            {
                Content = postContent,
                PostOn = DateTime.Now,
                PostedBy = this.User.Name
            };

            this.postContent.Text = string.Empty;
            this.crowdChatModule.AddPost(postModel);
            this.allPostsTextBox.Text += Environment.NewLine + this.crowdChatModule.GenerateOnePostAsString(postModel);
            this.allPostsTextBox.ScrollToEnd();
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