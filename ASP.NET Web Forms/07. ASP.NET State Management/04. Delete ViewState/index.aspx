<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="_04.Delete_ViewState.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <script src="Scripts/jquery-2.0.3.js"></script>
    </head>
    <body>
        <form id="MainForm" runat="server">
            <div>
                <asp:TextBox ID="TextBox" runat="server"></asp:TextBox>
                <asp:Button OnClick="OnButtonClicked" runat="server" Text="Submit" />
                <button id="del-viewstate-btn" >Delete ViewState</button>
                <asp:Label ID="Label" runat="server"></asp:Label>

            </div>
        </form>
        <script>
            $(document).ready(
                $("#MainForm").on("click", "#del-viewstate-btn", function () {
                    $("#__VIEWSTATE").val("");
                }));
        </script>
    </body>
</html>
