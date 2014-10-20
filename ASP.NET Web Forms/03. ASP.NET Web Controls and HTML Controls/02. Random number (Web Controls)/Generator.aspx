<%@ Page Title="Generator" 
         Language="C#" 
         AutoEventWireup="true" 
         CodeBehind="Generator.aspx.cs" 
         Inherits="RandomNumberWebControls.Generator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="mainForm" runat="server">
            <asp:TextBox name="minNumberInput" ID="minNumberInput" value="10" runat="server" /> <br /> <br />
            <asp:TextBox name="maxNumberInput" ID="maxNumberInput" value="100" runat="server" /> <br /> <br />
            <asp:Button type="submit" Text="Generate random number" runat="server" OnClick="OnGenerateRandomNumberButtonClicked" /> <br /> <br />
            <div id="randomNumberContainer" runat="server"></div>
        </form>
    </body>
</html>
