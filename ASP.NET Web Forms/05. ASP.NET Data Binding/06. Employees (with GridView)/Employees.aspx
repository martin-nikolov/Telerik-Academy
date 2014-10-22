<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="EmployeesGridView.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Employees</title>
    </head>
    <body>
        <form id="MainForm" runat="server">
            <asp:GridView ID="EmployeesGridView" runat="server" AutoGenerateColumns="False" 
                          AllowPaging="True" DataKeyNames="EmployeeID" PageSize="5"
                          onpageindexchanging="OnGridViewPageChanged">
                <Columns>
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:BoundField DataField="HomePhone" HeaderText="Phone" />
                </Columns>
            </asp:GridView>
        </form>
    </body>
</html>
