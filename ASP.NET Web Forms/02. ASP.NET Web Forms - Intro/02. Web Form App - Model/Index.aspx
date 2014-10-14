<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebFormAppModel.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Web Form App - Model</title>
    </head>
    <body>
        <form id="mainForm" runat="server">
            <asp:Label runat="server" ID="mainTextBlock"></asp:Label>
            <br />
            <asp:Label runat="server" ID="locationTextBlock"></asp:Label>
            <br />
            <br />
            <div>
                <strong>.aspx file</strong> containing HTML for visualization.
            </div>
            <div>
                <strong>"Code behind" files (.aspx.cs)</strong> containing the presentation logic for particular page. It separates the presentation logic from UI visualization.
            </div>
        </form>
    </body>
</html>
