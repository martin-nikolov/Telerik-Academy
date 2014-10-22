<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="EmployeesRepeater.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Employees</title>
    </head>
    <body>
        <form id="MainForm" runat="server">
            <asp:Repeater ID="EmployeesRepeater" runat="server" ItemType="EmployeesDataBinding.Models.Employee">
                <ItemTemplate>
                    <h4><%#: Item.FirstName + " " + Item.LastName %></h4>
                    <table border="0">
                        <tr>
                            <td>Phone:</td>
                            <td><%#: Item.HomePhone %></td>
                        </tr>
                        <tr>
                            <td>Country:</td>
                            <td><%#: Item.Country %></td>
                        </tr>
                        <tr>
                            <td>City:</td>
                            <td><%#: Item.City %></td>
                        </tr>
                    </table>

                    <hr />
                </ItemTemplate>
            </asp:Repeater>
        </form>
    </body>
</html>
