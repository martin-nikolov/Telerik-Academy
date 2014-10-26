<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="_02.Session_Object.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="MainForm" runat="server">
            <asp:TextBox ID="MainTextBox" runat="server"></asp:TextBox>
            <asp:Button OnClick="OnButtonClicked" runat="server" Text="Submit" />

            <asp:Label ID="MainLabel" runat="server"></asp:Label>
        </form>
    </body>
</html>
