<%@ Page Title="Friends" 
Language="C#" 
MasterPageFile="~/Site.Master" 
AutoEventWireup="true" 
CodeBehind="Friends.aspx.cs" 
Inherits="ProfilePage.Views.Friends" %>

<asp:Content ID="FriendsContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <ul class="friends-list">
        <li>
            <img src="http://telerikacademy.com/Content/Images/DefaultAvatar/default_180x180.jpg" alt="Ninja" width="75" height="75" />
            <span>Smith</span>
        </li>
        <li>
            <img src="http://telerikacademy.com/Content/Images/DefaultAvatar/default_180x180.jpg" alt="Ninja" width="75" height="75" />
            <span>John</span>
        </li>
        <li>
            <img src="http://telerikacademy.com/Content/Images/DefaultAvatar/default_180x180.jpg" alt="Ninja" width="75" height="75" />
            <span>George</span>
        </li>
        <li>
            <img src="http://telerikacademy.com/Content/Images/DefaultAvatar/default_180x180.jpg" alt="Ninja" width="75" height="75" />
            <span>Peter</span>
        </li>
    </ul>
</asp:Content>
