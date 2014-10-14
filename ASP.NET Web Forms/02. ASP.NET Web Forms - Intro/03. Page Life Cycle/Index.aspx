<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="PageLifeCycle.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Page Life Cycle</title>
    </head>
    <body>
        <form id="mainForm" runat="server">
            <asp:Button ID="mainButton" 
                        runat="server" 
                        OnInit="OnButtonInit" 
                        OnLoad="OnButtonLoad" 
                        OnClick="OnButtonClicked" 
                        OnPreRender="OnButtonPreRender" 
                        Text="Press" />
            <br />
            <asp:Label runat="server" ID="textBlock"></asp:Label>
        </form>
    </body>
</html>
