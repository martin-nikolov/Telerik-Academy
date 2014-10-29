namespace NewsSystem.Web.Controls
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class LikeControl : UserControl
    {
        public delegate void LikeEventHandler(object sender, LikeEventArgs e);

        public event LikeEventHandler Like;

        public int LikesValue { get; set; }

        public int DataID { get; set; }

        public bool? UserVote { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.LabelLikesCount.Text = this.LikesValue.ToString();

            if (this.UserVote.HasValue)
            {
                if (this.UserVote.Value)
                {
                    this.ButtonLike.Visible = false;
                    this.ButtonHate.Visible = true;
                }
                else
                {
                    this.ButtonLike.Visible = true;
                    this.ButtonHate.Visible = false;
                }
            }
        }

        protected void ButtonLike_Command(object sender, CommandEventArgs e)
        {
            bool likeValue = e.CommandName == "Like" ? true : false;
            this.Like(this, new LikeEventArgs(e.CommandArgument, likeValue));
        }
    }
}

namespace NewsSystem.Web.Controls
{
    using System;
    using System.Linq;

    public class LikeEventArgs : EventArgs
    {
        public LikeEventArgs(object dataID, bool likeValue)
        {
            this.DataID = dataID;
            this.LikeValue = likeValue;
        }

        public object DataID { get; set; }

        public bool LikeValue { get; set; }
    }
}