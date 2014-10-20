<%@ Page Title="Escaping" 
         Language="C#" 
         AutoEventWireup="true" 
         CodeBehind="Escaping.aspx.cs" 
         Inherits="EscapingHtml.Escaping" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="mainForm" runat="server">
            <asp:TextBox runat="server" Placeholder="Enter some text here..." ID="mainTextBox" />
            <asp:Button Text="submit" runat="server" OnClick="OnSubmitButtonClicked" />

            <br /> <br />

            <asp:TextBox runat="server" ID="enteredTextBox" /> <br /> <br />
            <asp:Label runat="server" ID="enteredTextLabel" />
        </form>
    </body>
</html>
