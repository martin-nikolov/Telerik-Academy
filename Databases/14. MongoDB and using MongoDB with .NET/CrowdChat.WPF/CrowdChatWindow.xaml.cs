namespace CrowdChat.WPF
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using CrowdChat.Data;
    using CrowdChat.Models;

    /// <summary>
    /// Interaction logic for CrowdChatWindow.xaml
    /// </summary>
    public partial class CrowdChatWindow : Window
    {
        private const string GitHubUri = "http://www.github.com/flextry";
        private Thread updatePostsThread;// XXX: bad
        CrowdChatModule crowdChatModule;

        public CrowdChatWindow(UserSession user)
        {
            this.InitializeComponent();
            this.User = user;
        }

        private UserSession User { get; set; }

        private bool IsInShowAllPostsMode { get; set; }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.updatePostsThread.Abort();
            App.Current.Shutdown();
        }

        private void OnWindowFormLoaded(object sender, RoutedEventArgs e)
        {
            this.InitializeCrowdChatModule();
            this.ShowAllPostsAsync(this.GetDateTimeRange());
            this.postContent.Focus();
            this.UpdatePostsEachMsAsync();
        }

        private void InitializeCrowdChatModule()
        {
            var mongoDbContext = new MongoDbContext();
            this.crowdChatModule = new CrowdChatModule(mongoDbContext);
        }

        private async void ShowAllPostsAsync(Tuple<DateTime, DateTime> dateTimeRanges)
        {
            var postsAsString = await this.GetPostsAsString(dateTimeRanges);
            this.allPostsTextBox.Text = postsAsString.ToString();
            this.allPostsTextBox.ScrollToEnd();
        }

        private Task<string> GetPostsAsString(Tuple<DateTime, DateTime> dateTimeRange)
        {
            return Task.Run(() =>
            { 
                return this.crowdChatModule.GenerateAllPostsAsString(dateTimeRange.Item1, dateTimeRange.Item2).ToString();
            });
        }

        private async void UpdatePostsEachMsAsync(int refreshMs = 500)
        {
            this.updatePostsThread = new Thread(() =>
            {
                while (true)
                {
                    this.allPostsTextBox.Dispatcher.BeginInvoke((Action)(async () => this.UpdatePosts()));
                    Thread.Sleep(refreshMs);
                }
            });

            this.updatePostsThread.Start();
        }
 
        private async void UpdatePosts()
        {
            var newPostsAsString = await this.GetPostsAsString(this.GetDateTimeRange());

            if (this.allPostsTextBox.Text != newPostsAsString)
            {
                this.allPostsTextBox.Text = newPostsAsString;
                this.allPostsTextBox.ScrollToEnd();
            }
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
            this.allPostsTextBox.Text += (this.allPostsTextBox.Text.Length > 0 ? Environment.NewLine : string.Empty) +
                                         this.crowdChatModule.GenerateOnePostAsString(postModel);
            this.allPostsTextBox.ScrollToEnd();
        }

        private void OnShowAllPostsButtonClick(object sender, RoutedEventArgs e)
        {
            this.IsInShowAllPostsMode = true;
            this.ShowAllPostsAsync(this.GetDateTimeRange());
        }

        private void OnShowAllPostsFromCurrentSessionButtonClick(object sender, RoutedEventArgs e)
        {
            this.IsInShowAllPostsMode = false;
            this.ShowAllPostsAsync(this.GetDateTimeRange());
        }

        private Tuple<DateTime, DateTime> GetDateTimeRange()
        {
            if (this.IsInShowAllPostsMode)
            {
                return Tuple.Create(DateTime.MinValue, DateTime.MaxValue);
            }
            else
            {
                return Tuple.Create(this.User.LoggedOn, DateTime.MaxValue);
            }
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