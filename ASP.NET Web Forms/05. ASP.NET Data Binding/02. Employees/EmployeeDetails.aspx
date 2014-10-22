<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="EmployeesDataBinding.EmployeeDetails" %>

<!DOCTYPE html>

<html>

    <head runat="server">
        <title>Employee Details</title>
    </head>

    <body>
        <form id="MainForm" runat="server">
            <asp:DetailsView ID="EmployeeDetailsView" runat="server" 
                             AutoGenerateRows="true" AllowPaging="True" >
            </asp:DetailsView>

            <br /> <br />

            <asp:Button Text="Back" runat="server" OnClick="OnBackButtonClicked" />
        </form>
    </body>

</html>
