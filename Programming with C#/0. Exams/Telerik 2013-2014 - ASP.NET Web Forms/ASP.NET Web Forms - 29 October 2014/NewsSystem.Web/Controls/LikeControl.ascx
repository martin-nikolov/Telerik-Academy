<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LikeControl.ascx.cs" Inherits="NewsSystem.Web.Controls.LikeControl" %>

<div class="like-control col-md-1">
    <div>
        <asp:Button runat="server" ID="ButtonLike" Text="Like" CommandName="Like" CommandArgument="<%# this.DataID %>" 
            OnCommand="ButtonLike_Command" />
        <asp:Label CssClass="like-value" runat="server" ID="LabelLikesCount" />
        <asp:Button runat="server" ID="ButtonHate" Text="Hate" CommandName="Hate" CommandArgument="<%# this.DataID %>" 
            OnCommand="ButtonLike_Command" />
    </div>
</div>