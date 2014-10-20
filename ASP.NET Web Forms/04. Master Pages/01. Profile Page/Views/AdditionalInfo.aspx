<%@ Page Title="Additional Information" 
         Language="C#" 
         MasterPageFile="~/Site.Master" 
         AutoEventWireup="true" 
         CodeBehind="AdditionalInfo.aspx.cs" 
         Inherits="ProfilePage.Views.AdditionalInfo" %>

<asp:Content ID="PassedCoursesContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div>Passed courses:</div>
    <ul>
        <li>JavaScript End-to-End - Excellent!</li>
        <li>ASP.NET MVC - Excellent!</li>
        <li>ASP.NET Web Forms - Excellent!</li>
    </ul>
</asp:Content>
